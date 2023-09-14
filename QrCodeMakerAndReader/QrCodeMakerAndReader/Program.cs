using System.Diagnostics;
using System.Drawing;
using ZXing;
using ZXing.Common;
// Veriyi al
Console.WriteLine("Veri girin:");
string data = Console.ReadLine();
string path = "qrcode.png";


// QrCode oluştur
CreateBarcode(path);

Console.WriteLine(Environment.CurrentDirectory + "\\" + path + " Adresinde Oluşturulan Qrcode'u Bulabilirsiniz");

// QrCode oku
WriteBarcode(path);


void CreateBarcode(string path)
{
    // Barcode oluştur
    BarcodeWriter writer = new BarcodeWriter();
    writer.Format = BarcodeFormat.QR_CODE;
    writer.Options = new EncodingOptions
    {
        Width = 400,
        Height = 400,
        Margin = 5
    };
    var result = writer.Write(data);
    result.Save(path);
}

void WriteBarcode(string path)
{
    var reader = new BarcodeReader();
    reader.Options = new DecodingOptions { TryHarder = true };
    var barcodeBitmap = new Bitmap(path);
    var result2 = reader.Decode(new Bitmap(path));
    Console.WriteLine("Barkoddan Okunan veri: " + result2.Text);
}
