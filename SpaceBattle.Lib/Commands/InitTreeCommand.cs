using Accord.MachineLearning.DecisionTrees.Learning;
using System.Data;
namespace SpaceBattle.Lib;

public class InitTreeCommand: ICommand{
    public void Execute(){
        string[][] data = ConvertCSVtoArray("../../Colision.csv", ',');
        double[][] input = new double[data.Length][];
        for(int i=0;i<data.Length;i++){
            input[i] = Array.ConvertAll(data[i].Take(4).ToArray(), x => Convert.ToDouble(x)); ;
        }
        int[] output = new int[data.Length];
        for(int i=0;i<data.Length;i++){
            output[i] = Convert.ToInt32(data[i].Last());
        }

        

        C45Learning c45learning = new C45Learning();
        var tree = c45learning.Learn(input, output);
        GetCollisionTree getTreeStrategy = new GetCollisionTree(tree);
        IoC.Resolve<ICommand>("IoC.Add", "Game.CollisionTree", getTreeStrategy).Execute();
    }

    static string[][] ConvertCSVtoArray (string strFilePath, char sep){
        DataTable dt = new DataTable();
        List<string[]> list = new List<string[]>();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] row = sr.ReadLine().Split(sep);
                list.Add(row);
            }
        }
        return list.ToArray();
    }
}
