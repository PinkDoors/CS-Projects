using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PeerGrade9
{
    public class Section:Node
    {
        public List<Item> ChildrenNodes { get; set; } = new List<Item>();
        public List<Section> ChildrenSections { get; set; } = new List<Section>();

    

        public Section(TreeNode newTreeNode)
        {
            TreeNode = newTreeNode;
            if (newTreeNode != null)
                Name = newTreeNode.Name;
        }

        /// <summary>
        /// Returns parent section for the selected tree node.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public Node this[TreeNode treeNode]
        {
            get
            {
                for (int i = 0; i < ChildrenNodes.Count; i++)
                {
                    if (ChildrenNodes[i].TreeNode == treeNode)
                        return ChildrenNodes[i];
                }
                for (int i = 0; i < ChildrenSections.Count; i++)
                {
                    if (ChildrenSections[i].TreeNode == treeNode)
                        return ChildrenSections[i];
                }
                return null;
            }
        }
    }
}
