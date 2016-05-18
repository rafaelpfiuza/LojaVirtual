﻿using System;
using System.Text;
using System.Web.Mvc;
using Rjsolutions.LojaVirtual.Web.Models;

namespace Rjsolutions.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaurl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 1; i < paginacao.TotalPaginas; i++)
            {
               TagBuilder tag = new TagBuilder("a"); 
                tag.MergeAttribute("href", paginaurl(i));
                tag.InnerHtml = i.ToString();

                if (i == paginacao.PaginaAtual)
                {
                   tag.AddCssClass("selected");
                   tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}