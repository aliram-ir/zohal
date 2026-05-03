using System.Diagnostics;
using Zohal.Abstractions;
using Zohal.Models;

namespace Test
{
    public partial class Form1 : Form
    {
        private readonly IZohalClient _zohal;

        public Form1(IZohalClient zohal)
        {
            InitializeComponent();
            _zohal = zohal;
        }

        //===========================================================
        //  استعلام هویت
        //===========================================================
        private async void NationalIdentityInquiryBtn_Click(object sender, EventArgs e)
        {
            var request = new NationalIdentityInquiryRequest
            {
                NationalCode = "1171293003",
                BirthDate = "1364/06/13"
            };

            var result = await _zohal.NationalIdentityInquiryAsync(request);

            // الگوی جدید Soft-Error
            if (result.IsSuccess)
            {
                var data = result.Data;
                MessageBox.Show($"{data?.FirstName} {data?.LastName}");
                Console.WriteLine($"{data?.FirstName} {data?.LastName}");
            }
            else
            {
                MessageBox.Show(result.Error?.Message ?? "خطای نامشخص");
                Console.WriteLine(result.Error?.Message.ToString());
            }
        }

        //===========================================================
        //  استعلام کارت
        //===========================================================
        private async void card_inquiryBtn_Click(object sender, EventArgs e)
        {
            var request = new CardInquiryRequest
            {
                CardNumber = "6037691590868097",
            };

            var result = await _zohal.CardInquiryAsync(request);

            if (result.IsSuccess)
            {
                var data = result.Data;
                MessageBox.Show(data?.Name ?? "نام موجود نیست");
                Console.WriteLine(data?.Name);
            }
            else
            {
                MessageBox.Show(result.Error?.Message ?? "خطای نامشخص");
                Console.WriteLine(result.Error?.Message.ToString());
            }
        }

        //===========================================================
        //  استعلام چک برگشتی
        //===========================================================
        private async void BouncedChequeBtn_Click(object sender, EventArgs e)
        {
            var request = new BouncedChequeRequest
            {
                NationalCode = "1171293003",
                NationalityType = 1,
            };

            var result = await _zohal.BouncedChequeAsync(request);

            if (result.IsSuccess)
            {
                var data = result.Data;
                MessageBox.Show(data?.Count.ToString() ?? "-1");
                Console.WriteLine(data?.Count.ToString());
            }
            else
            {
                MessageBox.Show(result.Error?.Message ?? "خطای نامشخص");
                Console.WriteLine(result.Error?.Message.ToString());
                Debug.WriteLine(result.Error?.Message.ToString());
            }
        }
    }
}
