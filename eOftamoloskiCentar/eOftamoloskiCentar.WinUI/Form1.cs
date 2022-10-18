namespace eOftamoloskiCentar.WinUI
{
    public partial class Form1 : Form
    {
        public APIService UposlenikService { get; set; } = new APIService("Uposlenik");
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var list = await UposlenikService.Get<dynamic>();

            var entitz = await UposlenikService.GetById<dynamic>(3);
        }
    }
}