using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PeerGrade9
{
    public class Node
    {
        [JsonIgnore]
        public TreeNode TreeNode { get; set; }
        public string Name { get; set; }
    }
}
