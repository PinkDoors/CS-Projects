using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PeerGrade9
{
    public class Item : Node
    {
        public string Code { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public string PathToPicture { get; set; }

        [JsonIgnore]
        public Bitmap Photo { get; set; }

        public Item(TreeNode newTreeNode)
        {
            TreeNode = newTreeNode;
            // Setting default image for item.
            Image defaultImage = Image.FromFile("DefaultImage.jpg");
            Bitmap newBitmmap = new Bitmap(defaultImage, defaultImage.Size);
            Photo = newBitmmap;
        }
    }
}
