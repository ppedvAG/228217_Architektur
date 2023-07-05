namespace HalloWinForms
{
    public class MyButton : Button
    {

        int count = 0;
        protected override void OnPaint(PaintEventArgs pevent)
        {

            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.Cyan, ClientRectangle);
            pevent.Graphics.DrawEllipse(new Pen(Brushes.DarkCyan, 4f), ClientRectangle);
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            pevent.Graphics.DrawString($"Paints: {count++}", new Font("Arial", 16f, FontStyle.Bold), Brushes.Black, ClientRectangle, sf);

            count++;
            //Text = $"Paints: {count++}";
        }
    }
}
