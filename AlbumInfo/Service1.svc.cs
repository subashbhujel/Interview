using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace AlbumInfo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    /// <summary>
    /// Q. [WCF Applications] You are tasked with writing WCF service methods capable of exposing song album information to clients. 
    /// The source information is available in the form of an XML file containing information about various song albums. 
    /// (Please see the attached song.xml file for some sample info). 
    /// 
    /// Provide the following functionality:
    /// a.            Get album details by name. (Return information about Songs in album.)
    /// b.            Add songs to an album
    /// c.            Update song info
    /// 
    /// While designing your services make the following considerations-
    /// a.     Handle Large XML files / Caching in memory.
    /// b.     Handle Concurrent access and large number of requests.
    /// 
    /// Solution Approach:
    /// Use XMLReader!
    ///     - Because it streams the document instead of loading the full thing into memory. So the actual querying should be reasonably quick on large documents.
    /// </summary>
    public class Service1 : IService1
    {
        const string songsFilePath = @"C:\Users\Subash\Documents\GitHub\Interview\AlbumInfo\Songs.xml";

        public bool AddSong(string name, string length, string artist, string album)
        {
            return AddSongs(name, length, artist, album);
        }

        public List<string> GetData(string albumName)
        {
            return GetAlbumDetails(albumName);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Get album details by name. (Return information about Songs in album.)
        /// </summary>
        /// <param name="songsFilePath"></param>
        /// <returns></returns>
        private List<string> GetAlbumDetails(string albumName)
        {
            List<string> albumInfo = new List<string>();

            try
            {
                XmlReader xmlReader = XmlReader.Create(songsFilePath);
                XDocument doc2 = XDocument.Load(xmlReader);


                foreach (var artist in doc2.Root.Descendants("artist"))
                {
                    foreach (var album in artist.Descendants("album"))
                    {
                        if (album.Attribute("title").Value.ToString().ToLower() == albumName.ToLower())
                        {
                            albumInfo.Add("Artist : " + artist.Attribute("name").Value.ToString());

                            foreach (var song in album.Descendants("song"))
                            {
                                albumInfo.Add(string.Format("Title : {0}; Length: {1}", song.Attribute("title").Value.ToString(),
                                                                                     song.Attribute("length").Value.ToString()));
                            }
                        }
                    }
                }

            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(string.Format("File doesn't exist : {0}", songsFilePath));

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return albumInfo;
        }

        /// <summary>
        ///     Add songs to an album
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool AddSongs(string name, string length, string artist, string album)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(length) ||
                string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(length))
            {
                return false;
            }

            try
            {
                /*
                 * XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml();

                XmlNode nonFuel = xmlDoc.SelectSingleNode("//NonFuel");
                XmlNode dispute = xmlDoc.SelectSingleNode("//Dispute");


                XmlNode xmlRecordNo=  xmlDoc.CreateNode(XmlNodeType.Element, "Records", null);
                xmlRecordNo.InnerText = Guid.NewGuid().ToString();
                nonFuel.InsertAfter(xmlRecordNo, dispute);
                */
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(songsFilePath);
                foreach (XmlNode xNodeArtist in xDoc.SelectNodes("//artist"))
                {
                    if (xNodeArtist.ToString().Equals(artist))
                    {
                        foreach (XmlNode xNodeAlbum in xDoc.SelectNodes("//album"))
                        {
                            if (xNodeAlbum.ToString().Equals(album))
                            {
                                string sss = xNodeArtist.Attributes[0].Value.ToString();
                                string s = xNodeAlbum.Attributes[0].Value.ToString();


                                XmlElement newSong = xDoc.CreateElement("song");

                                XmlAttribute songName = xDoc.CreateAttribute("title");
                                songName.Value = name;

                                XmlAttribute songLength = xDoc.CreateAttribute("length");
                                songLength.Value = length;

                                XmlAttribute songId = xDoc.CreateAttribute("Id");
                                songId.Value = "100";

                                newSong.Attributes.Append(songName);
                                newSong.Attributes.Append(songLength);
                                newSong.Attributes.Append(songId);

                                xNodeAlbum.AppendChild(newSong);
                                xNodeAlbum.InnerText = "myInnerText";
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private string GetAlbumName(string songName)
        {
            return string.Empty;
        }
    }
}
