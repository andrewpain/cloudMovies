using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace videoApp {
    [Serializable]
    public class savedInfo
    {
        public string nameOfPass = "pass";//pass
        public List<customVideo> videos = new List<customVideo>();
        public List<customPerformer> performers = new List<customPerformer>();
        public List<genre> genres = new List<genre>();
        public List<emailAccount> accounts = new List<emailAccount>();
    }


    public static class dataControl
    {
        public const string defNm = "Other";//default genre/actor's name/account that can't be deleted
        const string cName = "movieData.dat";
        const string cFolder = "pFiles/";
        public static savedInfo info;
        /*A separate holder used for images that are loaded from text files.
         Seperate files are used for images simply because, if saved with the main 'movieData.dat' file, 
         it would eventually get bigger, thus take longer to load. to avoid long loading time, separate files are made,
         and loaded asynchronously alongside each other and the application's main thread */
        public static List<guPix> images = new List<guPix>();
        //public static void deleteAllSavedData()
        //{
        //    string path1 = pFolder + pName;
        //    if (File.Exists(path1)) File.Delete(path1);
        //}


        //method that saves the data and image into separate text files, as explained above
        public static void saveInfo(guPix gp)
        {
            string path = cFolder + cName;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, info);
            stream.Close();

            if (gp != null)
            {
                FileStream stream2 = new FileStream(cFolder + gp.id + ".dat", FileMode.Create);
                formatter.Serialize(stream2, gp);
                stream.Close();
            }
        }
        //loads the data from the saved file
        public static void loadInfo()
        {
            string path = cFolder + cName;
            if (!Directory.Exists(cFolder))
            {
                Directory.CreateDirectory(cFolder);
            }
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                savedInfo data = formatter.Deserialize(stream) as savedInfo;
                stream.Close();
                info = data;
            }
            //if no file exist, then create a new one
            else
            {
                info = new savedInfo();
                info.performers.Add(new customPerformer() { picId = defNm, customName = defNm });
                info.genres.Add(new genre() { picId = defNm, customName = defNm });
                info.accounts.Add(new emailAccount() { picId = defNm, customName = defNm });
                saveInfo(new guPix() { id = defNm, pic = Properties.Resources.UI_Icon_Question });

            }

        }
        //this method loads the image from the individual file
        public static guPix loadGuPix(string id)
        {
            string path = cFolder + id + ".dat";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                guPix data = formatter.Deserialize(stream) as guPix;
                stream.Close();
                return data;
            }
            //if the image file does not exist return guPix object with the question mark instead of null
            else
            {
                //Debug.LogWarning("save file not found in: " + path);
                return new guPix() { id = id, pic = Properties.Resources.UI_Icon_Question };
            }
        }

        public static void deleteGuPix(string id)
        {
            string path = cFolder + id + ".dat";
            if (File.Exists(path)) File.Delete(path);

        }
    }

    //class that contains the image with id
    [Serializable]
    public class guPix
    {
        public string id = Guid.NewGuid().ToString();
        //public PixelHelper[,] pic;
        public Image pic;
    }
    //classes used to store information about films' metadata
    [Serializable]
    public abstract class customRecord
    {
        public string customName = "Other";
        public string picId;
    }
    [Serializable]
    public class customVideo : customRecord
    {
        public customPerformer[] performers;
        public genre[] genres;
        public emailAccount account;
        public string link = "";
    }
    [Serializable]
    public class customPerformer : customRecord
    {
    }
    [Serializable]
    public class genre : customRecord
    {
    }
    [Serializable]
    public class emailAccount : customRecord
    {
    }
    //[System.Serializable]
    //public class PixelHelper
    //{
    //    public int r, g, b;
    //}

    //public static class pixelCtrl
    //{
    //    public static PixelHelper[,] saveImage(Bitmap bmp)
    //    {
    //        PixelHelper[,] pixelBackup = new PixelHelper[bmp.Width,bmp.Height];
    //        int w = 0, h = 0;
    //        for (int i = 0; i < pixelBackup.Length; i++)
    //        {
    //            Color c = bmp.GetPixel(w, h);
    //            pixelBackup[w, h] = new PixelHelper() { r = c.R, g = c.G, b = c.B};
    //            w += 1;
    //            if (w >= bmp.Width) { w = 0; h += 1; }
    //        }
    //        return pixelBackup;
    //    }
    //    public static Bitmap loadImage(PixelHelper [,]ph)
    //    {

    //        //Bitmap bp = new Bitmap(null,ph.GetLength(0), ph.GetLength(1));
    //        Bitmap bp = new Bitmap(ph.GetLength(0), ph.GetLength(1));
    //        int w = 0, h = 0;
    //        for (int i = 0; i < ph.Length; i++)
    //        {
    //            Color nc = Color.FromArgb(ph[w, h].r, ph[w, h].g, ph[w, h].b);
    //            bp.SetPixel(w, h, nc);
    //            w += 1;
    //            if (w >= bp.Width) { w = 0; h += 1; }
    //        }
    //        return bp;
    //    }
    //}
}