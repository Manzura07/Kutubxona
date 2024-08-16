
class Dastur
{
    static List<Kitob> kitoblar = new List<Kitob>();
    static List<Foydalanuvchi> foydalanuvchilar = new List<Foydalanuvchi>();
    static Foydalanuvchi joriyFoydalanuvchi = null;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Ro'yxatdan o'tish");
            Console.WriteLine("2. Kitob qo'shish");
            Console.WriteLine("3. Kitoblarni ko'rish");
            Console.WriteLine("4. Kitob olish");
            Console.WriteLine("5. Kitobni qaytarish");
            Console.WriteLine("6. Chiqish");

            int tanlov = int.Parse(Console.ReadLine()!);

            switch (tanlov)
            {
                case 1:
                    RoyxatdanOtish();
                    break;
                case 2:
                    KitobQoshish();
                    break;
                case 3:
                    KitoblarniKorish();
                    break;
                case 4:
                    KitobOlish();
                    break;
                case 5:
                    KitobniQaytarish();
                    break;
                case 6:
                    System.Console.WriteLine("Dasturdan chiqilmoqda...");
                    return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov. Qaytadan urinib ko'ring.");
                    break;
            }
        }
    }

    static void RoyxatdanOtish()
    {
        Console.Write("Ismingizni kiriting: ");
        string ism = Console.ReadLine()!;
        Console.Write("Familiyangizni kiriting: ");
        string familiya = Console.ReadLine()!;
        joriyFoydalanuvchi = new Foydalanuvchi(ism, familiya);
        foydalanuvchilar.Add(joriyFoydalanuvchi);
        Console.WriteLine("Ro'yxatdan o'tish muvaffaqiyatli amalga oshirildi.");
    }

    static void KitobQoshish()
    {
        Console.Write("Kitob nomini kiriting: ");
        string nom = Console.ReadLine()!;
        Console.Write("Kitob muallifini kiriting: ");
        string muallif = Console.ReadLine()!;
        kitoblar.Add(new Kitob(nom, muallif));
        Console.WriteLine("Kitob muvaffaqiyatli qo'shildi.");
    }

    static void KitoblarniKorish()
    {
        if (kitoblar.Count == 0)
        {
            Console.WriteLine("Hech qanday kitob yo'q.");
            return;
        }

        Console.WriteLine("Mavjud kitoblar:");
        foreach (var kitob in kitoblar)
        {
            Console.WriteLine($"Nomi: {kitob.Nomi}, Muallifi: {kitob.Muallif}");
        }
    }

    static void KitobOlish()
    {
        Console.Write("Olish uchun kitob nomini kiriting: ");
        string nom = Console.ReadLine()!;
        var kitob = kitoblar.Find(k => k.Nomi.Equals(nom, StringComparison.OrdinalIgnoreCase));

        if (kitob == null)
        {
            Console.WriteLine("Kitob topilmadi.");
            return;
        }

        kitob.Olingan = true;
        kitob.Oluvchi = joriyFoydalanuvchi;
        Console.WriteLine("Kitob muvaffaqiyatli olindi.");
    }

    static void KitobniQaytarish()
    {
        Console.Write("Qaytarish uchun kitob nomini kiriting: ");
        string nom = Console.ReadLine()!;
        var kitob = kitoblar.Find(k => k.Nomi.Equals(nom, StringComparison.OrdinalIgnoreCase));

        if (kitob == null)
        {
            Console.WriteLine("Kitob topilmadi.");
            return;
        }

        if (!kitob.Olingan || kitob.Oluvchi != joriyFoydalanuvchi)
        {
            Console.WriteLine("Siz bu kitobni olmagansiz.");
            return;
        }

        kitob.Olingan = false;
        kitob.Oluvchi = null;
        Console.WriteLine("Kitob muvaffaqiyatli qaytarildi.");
    }
}

class Kitob
{
    public string Nomi { get; set; }
    public string Muallif { get; set; }
    public bool Olingan { get; set; } = false;
    public Foydalanuvchi Oluvchi { get; set; }
    public Kitob(string nomi, string muallif)
    {
        Nomi = nomi;
        Muallif = muallif;
    }
}

class Foydalanuvchi
{
    public string Ism { get; set; }
    public string Familiya { get; set; }

    public Foydalanuvchi(string ism, string familiya)
    {
        Ism = ism;
        Familiya = familiya;
    }
}