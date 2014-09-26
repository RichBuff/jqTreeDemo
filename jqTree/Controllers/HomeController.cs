using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jqTree.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTreeData()
        {
            var tntop = new TreeNode("Top", "0");
            var tn1 = new TreeNode("Item 1", "1");
            var tn2 = new TreeNode("Item 2", "1");
            var child1 = new TreeNode("citem1", "2");
            var child2 = new TreeNode("citem2", "3");
            var child3 = new TreeNode("citem3", "4");
            var children = new List<TreeNode>()
                {
                    tn1,
                    tn2
                };

            tn1.children = new List<TreeNode> { child1, child2 };
            tn2.children = new List<TreeNode>()
                {
                    child3
                };

            tntop.children = children;
            var top = new List<TreeNode>() { tntop };
            return Json(top, JsonRequestBehavior.AllowGet);
        }

    }

    public class TreeNode
    {
        public string label { get; set; }
        public string id { get; set; }
        public List<TreeNode> children { get; set; }

        public TreeNode(string label, string id)
        {
            this.label = label;
            this.id = id;
        }
    }

}
