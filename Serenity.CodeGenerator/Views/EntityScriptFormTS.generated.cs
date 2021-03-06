﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serenity.CodeGenerator.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class EntityScriptFormTS : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden
 public dynamic Model { get; set; } 
        public override void Execute()
        {


WriteLiteral(Environment.NewLine);



                                                   
    var dotModule = Model.Module == null ? "" : ("." + Model.Module);
    var moduleDot = Model.Module == null ? "" : (Model.Module + ".");

    Func<EntityField, string> gt = (f) => {
        if (f.FieldType == "String") {
            return "StringEditor";
        }
        else if (f.FieldType == "Int32" || f.FieldType == "Int16" || f.FieldType == "Int64") {
            return "IntegerEditor";
        }
        else if (f.FieldType == "Single" || f.FieldType == "Double" || f.FieldType == "Decimal") {
            return "DecimalEditor";
        }
        else if (f.FieldType == "DateTime") {
            return "DateEditor";
        }
        else if (f.FieldType == "Boolean") {
            return "BooleanEditor";
        }
        else
            return "StringEditor";
    };

    var fields = (IEnumerable<EntityField>)Model.Fields;
    var fieldList = String.Join(", ", fields.Where(x => x.Name != Model.Identity)
        .Select(x => "['" + x.Ident + "', () => Serenity." + gt(x) + "]"));



WriteLiteral(Environment.NewLine + "namespace ");


      Write(Model.RootNamespace);


                            Write(dotModule);

WriteLiteral(" {" + Environment.NewLine + "    export class ");


             Write(Model.ClassName);

WriteLiteral("Form extends Serenity.PrefixedContext {" + Environment.NewLine + "        static formKey = \'");


                      Write(moduleDot);


                                  Write(Model.ClassName);

WriteLiteral("\';" + Environment.NewLine + "    }" + Environment.NewLine + Environment.NewLine + "    export interface ");


                 Write(Model.ClassName);


                                       WriteLiteral("Form {");

                                              foreach (EntityField x in Model.Fields)
    {
        if (x.Ident != Model.Identity)
        {
WriteLiteral(Environment.NewLine + "        ");


    Write(x.Ident);

WriteLiteral(": Serenity.");


                         Write(gt(x));

WriteLiteral(";");


                                             }
    }

WriteLiteral(Environment.NewLine + "    }" + Environment.NewLine + Environment.NewLine + "    [");


Write(fieldList);

WriteLiteral("].forEach(x => Object.defineProperty(");


                                                Write(Model.ClassName);

WriteLiteral("Form.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as a" +
"ny)()); }, enumerable: true, configurable: true }));" + Environment.NewLine + "}");


        }
    }
}
#pragma warning restore 1591
