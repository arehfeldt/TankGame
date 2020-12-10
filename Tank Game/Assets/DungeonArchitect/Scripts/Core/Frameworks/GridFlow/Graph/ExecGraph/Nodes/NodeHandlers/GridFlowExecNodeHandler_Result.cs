using DungeonArchitect.Builders.GridFlow.Graphs.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonArchitect.Builders.GridFlow.Graphs.Exec.NodeHandlers
{
    [GridFlowExecNodeInfo("Result", "", 3000)]
    public class GridFlowExecNodeHandler_Result : GridFlowExecNodeHandler
    {
        private bool outputRaw = false;
        private bool outputPretty = false;
        private string path = @"C:\Users\Grant\Desktop\GraphNodeTest.txt";
        private GridFlowAbstractGraph myGraph;

        public override GridFlowExecNodeHandlerResultType Execute(GridFlowExecutionContext context, GridFlowExecRuleGraphNode node, out GridFlowExecNodeState ExecutionState, ref string errorMessage)
        {
            var tilemap = GridFlowExecNodeUtils.CloneIncomingTilemap(node, context.NodeStates);
            var graph = GridFlowExecNodeUtils.CloneIncomingAbstractGraph(node, context.NodeStates);
            ExecutionState = new GridFlowExecNodeState_Tilemap(tilemap, graph);

            //myGraph = graph;

   //         List<GridFlowAbstractGraphNode> graphNodes = graph.Nodes;
   //         List<GridFlowAbstractGraphNode> execStateNodes = ExecutionState.AbstractGraph.Nodes;
   //         using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Grant\Desktop\GraphNodeTest.txt"))
   //         {
   //             int i = 0;
   //             foreach (GridFlowAbstractGraphNode gNode in graphNodes)
   //             {
   //                 file.WriteLine(i);
   //                 file.WriteLine("Color: " + gNode.state.Color.ToString());
   //                 file.WriteLine("Room Type: " + gNode.state.RoomType.ToString());
   //                 file.WriteLine("Coordinates: " + gNode.state.GridCoord.x + ", " + gNode.state.GridCoord.y);
   //                 List<GridFlowItem> items = gNode.state.Items;
   //                 int j = 0;
   //                 foreach (GridFlowItem item in items)
   //                 {
   //                     file.WriteLine("Item List: ");
   //                     file.WriteLine("\t Item# " + i + " - " + j);
   //                     file.WriteLine("\t \t Marker Name: " + item.markerName);
   //                     file.WriteLine("\t \t Item Type: " + item.type.ToString());
   //                     j++;
			//		}
   //                 i++;
			//	}
			//}
   //         using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Grant\Desktop\ExecStateNodeTest.txt"))
   //         {
   //             int i = 0;
   //             foreach (GridFlowAbstractGraphNode gNode in execStateNodes)
   //             {
   //                 file.WriteLine(i);
   //                 file.WriteLine("Color: " + gNode.state.Color.ToString());
   //                 file.WriteLine("Room Type: " + gNode.state.RoomType.ToString());
   //                 file.WriteLine("Coordinates: " + gNode.state.GridCoord.x + ", " + gNode.state.GridCoord.y);
   //                 List<GridFlowItem> items = gNode.state.Items;
   //                 int j = 0;
   //                 foreach (GridFlowItem item in items)
   //                 {
   //                     file.WriteLine("Item List: ");
   //                     file.WriteLine("\t Item# " + i + " - " + j);
   //                     file.WriteLine("\t \t Marker Name: " + item.markerName);
   //                     file.WriteLine("\t \t Item Type: " + item.type.ToString());
   //                     j++;
   //                 }
   //                 i++;
   //             }
   //         }

            return GridFlowExecNodeHandlerResultType.Success;
        }

        private void Analyze()
        {
            
		}

        /* Outputs to .txt file on given path the following info:
         * Node#
         * Color in unity color format 
         * Room Type
         * X,Y Coordinates as int
         *      > for 8x8 grid room 0 is 0,0, room 1 is 1,0, ..., room 8 is 0,1
         * Item List (for our use its just a list of enemies)
         *      > Item# (Node# - Item# for that node)
         *          > Marker Name (For enemies is "Grunt")
         *          > Item Type (For enemies is "Enemy")
         */
        private void PrintRawInfo(string path)
        {
            List<GridFlowAbstractGraphNode> graphNodes = myGraph.Nodes;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                int i = 0;
                foreach (GridFlowAbstractGraphNode gNode in graphNodes)
                {
                    file.WriteLine(i);
                    file.WriteLine("Color: " + gNode.state.Color.ToString());
                    file.WriteLine("Room Type: " + gNode.state.RoomType.ToString());
                    file.WriteLine("Coordinates: " + gNode.state.GridCoord.x + ", " + gNode.state.GridCoord.y);
                    List<GridFlowItem> items = gNode.state.Items;
                    int j = 0;
                    file.WriteLine("Item List: ");
                    foreach (GridFlowItem item in items)
                    {
                        file.WriteLine("\t Item# " + i + " - " + j);
                        file.WriteLine("\t \t Marker Name: " + item.markerName);
                        file.WriteLine("\t \t Item Type: " + item.type.ToString());
                        j++;
                    }
                    i++;
                }
            }
        }

        /* Outputs to given path the nodes organized by color
         * 
         */
        private void PrintPrettyInfo(string path)
        {
            List<string> colorList = new List<string>();
            colorList.Add("red");
            colorList.Add("orange");
            colorList.Add("yellow");
            colorList.Add("green");
            colorList.Add("blue");

            List<GridFlowAbstractGraphNode> graphNodes = myGraph.Nodes;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                int i = 0;
                foreach (string color in colorList) 
                {
                    GridFlowAbstractGraphNode[] colorNodes = GetPathNodes(GetNodeWithColor(color).state.Color);
                    file.WriteLine(color);
                    file.WriteLine();
                }
			}

        }

        /*
         * Searches current list of nodes in graph for one with the desired color
         * If one can not be found returns a null node
         */
        private GridFlowAbstractGraphNode GetNodeWithColor(string color)
        {
            GridFlowAbstractGraphNode targetNode = null;
            bool found = false;
            List<GridFlowAbstractGraphNode> graphNodes = myGraph.Nodes;
            for(int i = 0; i < 63 && !found; i++)
            {
                if (ColorToString(graphNodes[i].state.Color).Equals(color))
                {
                    targetNode = graphNodes[i];
                    found = true;
				}
			}

            return targetNode;
        }

        // Returns a list of all nodes in the current abstract graph which have the given color
        // Color should be passed from pre existing nodes
        private GridFlowAbstractGraphNode[] GetPathNodes(Color pathColor)
        {
            GridFlowAbstractGraphNode[] nodeList = new GridFlowAbstractGraphNode[8];
            List<GridFlowAbstractGraphNode> graphNodes = myGraph.Nodes;
            int i = 0;
            foreach (GridFlowAbstractGraphNode node in graphNodes)
            {
                if (node.state.Color.Equals(pathColor))
                {
                    nodeList[i] = node;
                    i++;
				}
			}

            return nodeList;
		}

        // Converts RGBA color values to strings
        // based upon preset colors, if preset path color changes this wont work 
        private string ColorToString(Color givenColor)
        {
            string color;
            if (givenColor.r == 1f)
            {
                if (givenColor.g == 0f)
                {
                    color = "red";
                }
                else if (givenColor.g == 0.500f)
                {
                    color = "orange";
                }
                else
                {
                    color = "yellow";
                }
            }
            else
            {
                if (givenColor.g == 1f)
                {
                    color = "green";
                }
                else
                {
                    color = "blue";
                }
            }
            return color;
        }
    }
}
