using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class changeText : MonoBehaviour
{

    public Text changeTex;
    public GameObject kurwa;
    private StringBuilder txt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextChangeIntro()
    {
        kurwa.SetActive(true);
        txt = new StringBuilder();
        txt.AppendLine("");
        txt.AppendLine("");
        txt.AppendLine("");
        txt.AppendLine("____________________________________________________________________________________________");
        txt.AppendLine("");
        txt.AppendLine("C O M M E N T S");
        txt.AppendLine("");
        txt.AppendLine("_____________________________________________");
        txt.AppendLine("");
        txt.AppendLine("Comments are bits of text that are not executed.These lines can be used to leave\n notes and increase the readability of the program.");
        txt.AppendLine("");
        txt.AppendLine("Single line comments are created with two forward slashes //.");
        txt.AppendLine("Multi - line comments start with /* and end with */.");
        txt.AppendLine("");
        txt.AppendLine("They are useful for commenting out large blocks of code.");
        txt.AppendLine("// This is a single line comment");
        txt.AppendLine("/* This is a multi-line comment");
        txt.AppendLine("and continues until the end");
        txt.AppendLine("of comment symbol is reached */");
        txt.AppendLine("");
        txt.AppendLine("____________________________________________________________________________________________");
        txt.AppendLine("");
        txt.AppendLine("W R I T E  I N  T H E  C O N S O L E");
        txt.AppendLine("");
        txt.AppendLine("_____________________________________________");
        txt.AppendLine("");
        txt.AppendLine("The Console.WriteLine() method is used to print text to the console. It can also\n be used to print other data types and values stored in variables.");
        txt.AppendLine("");
        txt.AppendLine("Console.WriteLine(\"Hello, world!\")");
        txt.AppendLine("");
        txt.AppendLine("// Prints: Hello, world!");
        txt.AppendLine("____________________________________________________________________________________________");

        changeTex.text = txt.ToString();

    }
    public void TextChangeDataTypes()
    {
        kurwa.SetActive(true);
        txt = new StringBuilder();
        txt.AppendLine("");
        txt.AppendLine("");
        txt.AppendLine("");
        txt.AppendLine("____________________________________________________________________________________________");
        txt.AppendLine("");
        txt.AppendLine("V A R I A B L E S  A N D  T Y P E S");
        txt.AppendLine("");
        txt.AppendLine("_____________________________________________");
        txt.AppendLine("");
        txt.AppendLine("A variable is a way to store data in the computer’s memory to be used later in the program.\n C# is a type-safe language, meaning that when variables are declared it is necessary to\n define their data type.");
        txt.AppendLine("");
        txt.AppendLine("Declaring the types of variables allows the compiler to stop the program from being run when\n variables are used incorrectly, i.e, an int being used when a string is needed or vice versa.");
        txt.AppendLine("CODE EXAMPLE:");
        txt.AppendLine("string foo = \"Hello\";");
        txt.AppendLine("string bar = \"How are you ?\";");
        txt.AppendLine("int x = 5;");
        txt.AppendLine("Console.WriteLine(foo);");
        txt.AppendLine("// Prints: Hello");
        txt.AppendLine("");
        txt.AppendLine("____________________________________________________________________________________________");
        txt.AppendLine("");
        txt.AppendLine("A R I T H M E T I C  O P E R A T O R S");
        txt.AppendLine("");
        txt.AppendLine("_____________________________________________");
        txt.AppendLine("");
        txt.AppendLine("Arithmetic operators are used to modify numerical values:");
        txt.AppendLine("+ addition operator");
        txt.AppendLine("- subtraction operator");
        txt.AppendLine("* multiplication operator");
        txt.AppendLine("/ division operator");
        txt.AppendLine("% modulo operator (returns the remainder)");
        txt.AppendLine("____________________________________________________________________________________________");
        txt.AppendLine("");
        txt.AppendLine("R E L A T I O N A L  O P E R A T O R S");
        txt.AppendLine("");
        txt.AppendLine("_____________________________________________");
        txt.AppendLine("");
        txt.AppendLine("These are operators used for performing Relational operations on numbers.\n Below is the list of relational operators available in C#.");
        txt.AppendLine("==	Checks if the values of two operands are equal or not, if yes then condition becomes true.");
        txt.AppendLine("!=	Checks if the values of two operands are equal or not, if values are not equal then condition becomes true.");
        txt.AppendLine(">	Checks if the value of left operand is greater than the value of right operand, if yes then condition becomes true.");
        txt.AppendLine("<	Checks if the value of left operand is less than the value of right operand, if yes then condition becomes true.");
        txt.AppendLine(">=	Checks if the value of left operand is greater than or equal to the value of right operand, if yes then condition becomes true.");
        txt.AppendLine("<=	Checks if the value of left operand is less than or equal to the value of right operand, if yes then condition becomes true.");
        txt.AppendLine("____________________________________________________________________________________________");


        changeTex.text = txt.ToString();
    }
}