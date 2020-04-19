using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Util
{
    public class GridPageHelper: ITemplate
    {
        public GridView AssociatedGridView { get; private set; }

        private HtmlGenericControl First;
        private HtmlGenericControl Last;
        private HtmlGenericControl Prev;
        private HtmlGenericControl Next;
        private HtmlGenericControl RowCount;

        public GridPageHelper(GridView associatedGridView)
        {
            this.AssociatedGridView = associatedGridView;

            First = new HtmlGenericControl("i");
            First.Attributes.Add("class", "fa fa-angle-double-left");

            Last = new HtmlGenericControl("i");
            Last.Attributes.Add("class", "fa fa-angle-double-right");

            Prev = new HtmlGenericControl("i");
            Prev.Attributes.Add("class", "fa fa-angle-left");

            Next = new HtmlGenericControl("i");
            Next.Attributes.Add("class", "fa fa-angle-right");

            RowCount = new HtmlGenericControl("span");
            RowCount.Attributes.Add("style", "float:left");
        }

        public void InstantiateIn(Control container)
        {
            Panel pnlGroup = new Panel();
            pnlGroup.CssClass = "btn-group";

            double aux = this.AssociatedGridView.PageIndex / 10;
            int inicio = (int)Math.Truncate(aux) * 10;
            int fim = (inicio + 10 < this.AssociatedGridView.PageCount) ? inicio + 10 : this.AssociatedGridView.PageCount;

            //Botão para primeira página
            if (inicio > 0) pnlGroup.Controls.Add(getLi("First"));

            //Botão para a página anterior
            if (this.AssociatedGridView.PageIndex != 0) pnlGroup.Controls.Add(getLi("Prev"));

            //Botões numerados
            for (int i = inicio; i < fim; i++)
            {
                pnlGroup.Controls.Add(getLi((i+1).ToString(), (i != this.AssociatedGridView.PageIndex)));
            }

            //Botão para a próxima página
            if (this.AssociatedGridView.PageIndex != this.AssociatedGridView.PageCount - 1) pnlGroup.Controls.Add(getLi("Next"));

            //Botão para a última página
            if (this.AssociatedGridView.PageCount > fim) pnlGroup.Controls.Add(getLi("Last"));

            //Recriando o span, pois ele estava concatenando as informaçoes do registro
            RowCount = new HtmlGenericControl("span");
            RowCount.Attributes.Add("style", "float:left");
            RowCount.Controls.Add(getRow());

            container.Controls.Add(pnlGroup);
            container.Controls.Add(RowCount);

        }

        private Control getLi(string Argument, bool enabled = true)
        {
            if (enabled)
            {
                LinkButton lnkPage = new LinkButton();
                lnkPage.CssClass = "btn btn-default";
                lnkPage.CommandName = "Page";
                lnkPage.CommandArgument = Argument;
                lnkPage.OnClientClick = "$.blockUI();";

                switch (Argument)
                {
                    case "First": lnkPage.Controls.Add(First); break;
                    case "Last": lnkPage.Controls.Add(Last); break;
                    case "Prev": lnkPage.Controls.Add(Prev); break;
                    case "Next": lnkPage.Controls.Add(Next); break;
                    default: lnkPage.Text = Argument; break;
                }

                return lnkPage;
            }

            Label label = new Label();
            label.CssClass = "btn btn-default disabled";
            label.Text = Argument;
            return label;
        }

        private Control getRow()
        {
            Label lnkPage = new Label();
            var quantidade = AssociatedGridView.VirtualItemCount;
            var size = AssociatedGridView.PageSize;
            var page = AssociatedGridView.PageIndex;
            var a = AssociatedGridView.PageCount;

            int from = page * size + 1;
            int to = page * size + size;

            lnkPage.Text = string.Empty;
            lnkPage.Text = $"Mostrando de {page * size + 1} até {(to <= quantidade ? to : quantidade) } de {quantidade} registros";

            return lnkPage;
        }
    }
}
           
           