using Accord.MachineLearning.DecisionTrees;
namespace SpaceBattle.Lib;

public class InitTreeCommand: ICommand{
    public void Execute(){
        DataTable data = ConvertCSVtoDataTable("../../Colision.csv");
        string[] inputColumns = new[]{"x1","y1","x2","y2"};
        DataTable input = new DataView(data).ToTable(false, inputColumns);
        DataTable output = data.Columns["result"];
        //Codification codebook = new Codification(data);
        /*DecisionVariable[] attributes = {
        new DecisionVariable("x1"),
        new DecisionVariable("y1"),
        new DecisionVariable("x2"),   
        new DecisionVariable("y2")
        };*/

        C45Learning c45learning = new C45Learning();
        var tree = c45learning.Learn(input, output);
        GetCollisionTree getTreeStrategy = new GetCollisionTree(tree);
        IoC.Resolve<ICommand>("IoC.Add", "Game.CollisionTree", getTreeStrategy).Execute();
    }

    static DataTable ConvertCSVtoDataTable (string strFilePath, char sep){
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            string[] headers = sr.ReadLine().Split(sep);
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(sep);
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
        }
        return dt;
    }
}
