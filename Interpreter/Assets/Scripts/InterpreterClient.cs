using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InterpreterClient : MonoBehaviour
{
    public string ParseInput(string input)
    {
        if (input != "")
        {
            List<string> tokens = new(input.Split(" "));
            List<IExpression> expressions = new List<IExpression>(new IExpression[tokens.Count]);
            bool isValid = true;
            for (int i = 0; i < tokens.Count && isValid; i ++)
            {
                if (i % 2 == 0 && !float.TryParse(tokens[i], out float output))
                    isValid = false;
                else if (i % 2 != 0 && (tokens[i] != "*" && tokens[i] != "-" && tokens[i] != "+" && tokens[i] != "/"))
                    isValid = false;
                expressions[i] = GetExpression(tokens[i], null, null);
            }

            if (isValid)
            {
                while (expressions.Count > 1)
                {
                    IExpression expression = null;
                    IExpression multDivExp = expressions.FirstOrDefault(x => x.LeftExpression == null && (x.GetType() == typeof(MultiplyExpression) || x.GetType() == typeof(DivideExpression)));
                    if (multDivExp != null)
                        expression = multDivExp;
                    else
                    {
                        IExpression subAddExp = expressions.FirstOrDefault(x => x.LeftExpression == null && (x.GetType() == typeof(AddExpression) || x.GetType() == typeof(SubtractExpression)));
                        if (subAddExp != null)
                            expression = subAddExp;
                    }

                    if (expression == null) break;

                    expression.LeftExpression = expressions[expressions.IndexOf(expression) - 1];
                    expression.RightExpression = expressions[expressions.IndexOf(expression) + 1];
                    expressions.RemoveAt(expressions.IndexOf(expression) + 1);
                    expressions.RemoveAt(expressions.IndexOf(expression) - 1);
                }
                Context ctx = new();
                return expressions[0].Evaluate(ctx).ToString();
            }
        }
        return "";
    }

    private IExpression GetExpression (string operand, IExpression left, IExpression right)
    {
        switch (operand) {
            case "*":
                return new MultiplyExpression(left, right);
            case "/":
                return new DivideExpression(left, right);
            case "+":
                return new AddExpression(left, right);
            case "-":
                return new SubtractExpression(left, right);
            default:
                if (float.TryParse(operand, out float output))
                    return new NumberExpression(output);
                return null;
        }
    }
}
