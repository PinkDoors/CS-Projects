using System;
using System.Windows.Forms;

namespace PeerGrade9
{
    public partial class NodeName : Form
    {
        bool isThereSuchAName;
        public NodeName()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NodeName_FormClosing(object sender, FormClosingEventArgs e)
        {
            isThereSuchAName = false;
            try
            {
                // Getting the parent section for the selected node.
                Section parent = SellerForm.newWarehouse.GetSectionByTreeNode(SellerForm.ParentNode, SellerForm.newWarehouse.Root);
                // Checking if the selected section is not a root.
                if (SellerForm.ParentNode != null)
                {
                    // Checking if there is already an item with such a name.
                    for (int i = 0; i < parent.ChildrenNodes.Count; i++)
                    {
                        if (parent.ChildrenNodes[i].TreeNode.Text == NewNameTextBox.Text)
                        {
                            isThereSuchAName = true;
                        }
                    }
                    // Checking if there is already a section with such a name.
                    for (int i = 0; i < parent.ChildrenSections.Count; i++)
                    {
                        if (parent.ChildrenSections[i].TreeNode.Text == NewNameTextBox.Text)
                        {
                            isThereSuchAName = true;
                        }
                    }
                    if (isThereSuchAName)
                    {
                        MessageBox.Show("This name already exists or it is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        NodeName changeNodeName = new NodeName();
                        changeNodeName.Show();
                    }
                    else
                    {
                        SellerForm.ChildNode.Text = NewNameTextBox.Text;
                        parent[SellerForm.ChildNode].Name = NewNameTextBox.Text;
                        (Application.OpenForms[1] as SellerForm).Tree_AfterSelect(null, null);
                    }
                }
                else
                {
                    SellerForm.ChildNode.Text = NewNameTextBox.Text;
                    // Changing the name of the root.
                    SellerForm.newWarehouse.GetSectionByTreeNode(SellerForm.ChildNode, SellerForm.newWarehouse.Root).Name = NewNameTextBox.Text;
                    (Application.OpenForms[1] as SellerForm).Tree_AfterSelect(null, null);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
