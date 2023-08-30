using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class TransformInfo
{
    public Vector3 position;
    public Quaternion rotation;
}

public class DrawTree : MonoBehaviour
{
    [SerializeField] private int iterations;
    [SerializeField] private GameObject Branch;
    [SerializeField] private GameObject Tree;

    [SerializeField] private float length = 50f;


    public Transform InstantiateMe;

    private Stack<TransformInfo> newStack;

    private Dictionary<char, string> rules;
    private const string axiom = "X";
    private string currentString = string.Empty;   


    void Start()
    {
        var random = new System.Random();

        string[] selection = new string [] {"F[[X]+X]+F[+FX]-X"};
        int index = random.Next(selection.Length);
        string entry = selection[index];
        newStack = new Stack<TransformInfo>();
        rules = new Dictionary<char, string>
        {
                {'X', entry},
                {'F', "FF"}
        };
        Generate();    
        
   
    }
    
    public void Generate()
    {
        currentString = axiom;
        StringBuilder sBuilder = new StringBuilder();

        for (int i=0; i < iterations; i++)
        {
            foreach (char c in currentString)
            {
                sBuilder.Append(rules.ContainsKey(c) ? rules [c] : c.ToString());
            }
            currentString = sBuilder.ToString();
            sBuilder = new StringBuilder();
        }
         foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F':
                Vector3 initialPos = transform.position;
                transform.Translate(Vector3.up * length);

               // GameObject clone = Instantiate(Tree, initialPos, Quaternion.identity) as GameObject;

                GameObject treeSegment = Instantiate(Branch);
                //GameObject treeSegment = Instantiate(Tree);


                treeSegment.GetComponent<LineRenderer>().SetPosition(0, initialPos);
                treeSegment.GetComponent<LineRenderer>().SetPosition(1, transform.position);    
                break;

                case 'X':            
                break;

                case '+':
                transform.Rotate(Vector3.back * UnityEngine.Random.Range(-30.0f, 30.0f));
                break;

                case '-':
                transform.Rotate(Vector3.forward * UnityEngine.Random.Range(-30.0f, 30.0f));
                break;

                case '<':
                transform.Rotate(Vector3.left * UnityEngine.Random.Range(-30.0f, 30.0f));
                break;

                case '>':
                transform.Rotate(Vector3.down * UnityEngine.Random.Range(-30.0f, 30.0f));
                break;

                case '[':
                newStack.Push(new TransformInfo()
                {
                    position = transform.position,
                    rotation = transform.rotation
                });
                break;

                case ']':
                TransformInfo transformInfo = newStack.Pop();
                transform.position = transformInfo.position; 
                transform.rotation = transformInfo.rotation;
                break;

               case ',':

                default:
                throw new InvalidOperationException("broken");
            
        }
        
            }
            }
            }        

