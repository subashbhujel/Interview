using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
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

        public string GetData(int value)
        {
            return ReadSongs(songsFilePath);
            //return string.Format("You entered: {0}", value);
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

        private string ReadSongs(string songsFilePath)
        {
            try
            {
                XmlReader xmlReader = XmlReader.Create(songsFilePath);
                while (xmlReader.Read())
                {
                    switch (xmlReader.Name)
                    {
                        case "artist":
                            return xmlReader["name"];
                        case "album":
                            return xmlReader["title"];;
                        default:
                            break;
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
            return "nothing";
        }
    }
}
