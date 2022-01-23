using System.Windows.Forms;

namespace PeerGrade9
{
    public class Warehouse
    {
        public Section Root { get; set; }

        public Warehouse(Section root)
        {
            Root = root;
        }


        /// <summary>
        /// Gets the section by the selected tree node.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="currentSection"></param>
        /// <returns></returns>
        public Section GetSectionByTreeNode(TreeNode treeNode, Section currentSection)
        {
            if (currentSection.TreeNode == treeNode)
                return currentSection;
            for (int i = 0; i < currentSection.ChildrenSections.Count; i++)
            {
                Section nextSection = GetSectionByTreeNode(treeNode, currentSection.ChildrenSections[i]);
                if (nextSection != null)
                    return nextSection;
            }
            return null;
        }

        /// <summary>
        /// Gets the item by the selected tree node.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="currentSection"></param>
        /// <returns></returns>
        public Item GetItemByTreeNode(TreeNode treeNode, Section currentSection)
        {
            for (int i = 0; i < currentSection.ChildrenNodes.Count; i++)
            {
                if (treeNode == currentSection.ChildrenNodes[i].TreeNode)
                    return currentSection.ChildrenNodes[i];
            }
            for (int i = 0; i < currentSection.ChildrenSections.Count; i++)
            {
                Item nextItem = GetItemByTreeNode(treeNode, currentSection.ChildrenSections[i]);
                if (nextItem != null)
                    return nextItem;
            }
            return null;
        }

    }
}
