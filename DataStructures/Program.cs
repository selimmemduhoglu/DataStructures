using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDataStructuresExamples
{
	class Program
	{
		static async Task Main(string[] args)
		{
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("=== .NET Veri Yapıları Örnekleri ===");
				Console.WriteLine("1. List<T>");
				Console.WriteLine("3. Array");
				Console.WriteLine("2. Dictionary<TKey, TValue>");
				Console.WriteLine("4. HashSet<T>");
				Console.WriteLine("5. Queue<T>");
				Console.WriteLine("6. Stack<T>");
				Console.WriteLine("7. LinkedList<T>");
				Console.WriteLine("8. Tuple ve ValueTuple");
				Console.WriteLine("9. ConcurrentDictionary<TKey, TValue>");
				Console.WriteLine("10. ImmutableList<T>");
				Console.WriteLine("11. ObservableCollection<T>");
				Console.WriteLine("12. ReadOnlyCollection<T>");
				Console.WriteLine("13. SortedDictionary<TKey, TValue>");
				Console.WriteLine("14. ConcurrentQueue<T>");
				Console.WriteLine("15. MemoryCache");
				Console.WriteLine("16. DataTable / DataSet");
				Console.WriteLine("17. BitArray");
				Console.WriteLine("18. Span<T> / Memory<T>");
				Console.WriteLine("19. BlockingCollection<T>");
				Console.WriteLine("20. KeyValuePair<TKey, TValue>");
				Console.WriteLine("0. Çıkış");
				Console.Write("\nSeçiminiz: ");




				if (int.TryParse(Console.ReadLine(), out int choice))
				{
					Console.Clear();
					switch (choice)
					{
						case 0:
							exit = true;
							break;
						case 1:
							ListExample();
							break;
						//case 2:
						//	DictionaryExample();
						//	break;
							//case 3:
							//	ArrayExample();
							//	break;
							//case 4:
							//	HashSetExample();
							//	break;
							//case 5:
							//	QueueExample();
							//	break;
							//case 6:
							//	StackExample();
							//	break;
							//case 7:
							//	LinkedListExample();
							//	break;
							//case 8:
							//	TupleExample();
							//	break;
							//case 9:
							//	await ConcurrentDictionaryExample();
							//	break;
							//case 10:
							//	ImmutableListExample();
							//	break;
							//case 11:
							//	ObservableCollectionExample();
							//	break;
							//case 12:
							//	ReadOnlyCollectionExample();
							//	break;
							//case 13:
							//	SortedDictionaryExample();
							//	break;
							//case 14:
							//	await ConcurrentQueueExample();
							//	break;
							//case 15:
							//	MemoryCacheExample();
							//	break;
							//case 16:
							//	DataTableExample();
							//	break;
							//case 17:
							//	BitArrayExample();
							//	break;
							//case 18:
							//	SpanMemoryExample();
							//	break;
							//case 19:
							//	await BlockingCollectionExample();
							//	break;
							//case 20:
							//	KeyValuePairExample();
							//	break;
							//default:
							//	Console.WriteLine("Geçersiz seçim!");
							//	break;
					}

					if (choice != 0)
					{
						Console.WriteLine("\nDevam etmek için bir tuşa basın...");
						Console.ReadKey();
					}
				}
			}
		}

		#region 1.List<T>
		static void ListExample()
		{
			Console.WriteLine("=== List<T> Örneği ===");
			Console.WriteLine("List<T>, dinamik boyutlu bir dizi yapısıdır. Eleman ekleme, çıkarma, erişim gibi işlemler için kullanılır.");

			// List oluşturma
			List<string> sehirler = new List<string>();

			// Eleman ekleme
			Console.WriteLine("\n1. Eleman Ekleme (Add):");
			sehirler.Add("İstanbul");
			sehirler.Add("Ankara");
			sehirler.Add("İzmir");
			sehirler.ForEach(x => Console.WriteLine(x));

			// AddRange ile birden fazla eleman ekleme
			Console.WriteLine("\n2. Çoklu Eleman Ekleme (AddRange):");
			List<string> addRangeSehirler = new List<string>();
			addRangeSehirler.Add("Bursa");
			addRangeSehirler.Add("Antalya");
			addRangeSehirler.Add("Adana");
			sehirler.AddRange(addRangeSehirler);
			//sehirler.AddRange(new[] { "Bursa", "Antalya", "Adana" });
			sehirler.ForEach(x => Console.WriteLine(x));

			// Insert ile araya eleman ekleme
			Console.WriteLine("\n3. Araya Eleman Ekleme (Insert):");
			sehirler.Insert(3, "Trabzon");
			sehirler.ForEach(x => Console.WriteLine(x));

			// Contains ile eleman arama
			Console.WriteLine("\n4. Eleman Arama (Contains):");
			Console.WriteLine($"'Ankara' listede var mı? {sehirler.Contains("Ankara")}");
			Console.WriteLine($"'Kayseri' listede var mı? {sehirler.Contains("Kayseri")}");

			// IndexOf ile eleman indeksini bulma
			Console.WriteLine("\n5. Eleman İndeksini Bulma (IndexOf):");
			Console.WriteLine($"'İzmir'in indeksi: {sehirler.IndexOf("İzmir")}");

			// İndeks ile erişim
			Console.WriteLine("\n6. İndeks ile Erişim:");
			Console.WriteLine($"2. indeksteki şehir: {sehirler[2]}");

			// Remove ile eleman çıkarma
			Console.WriteLine("\n7. Eleman Çıkarma (Remove):");
			sehirler.Remove("Adana");
			sehirler.ForEach(x => Console.WriteLine(x));

			// RemoveAt ile indeks ile eleman çıkarma
			Console.WriteLine("\n8. İndeks ile Eleman Çıkarma (RemoveAt):");
			sehirler.RemoveAt(1);
			//PrintCollection(sehirler);
			sehirler.ForEach(x => Console.WriteLine(x));

			// FindAll ile koşulu sağlayan elemanları bulma
			Console.WriteLine("\n9. Koşullu Eleman Bulma (FindAll):");
			List<string> iIleBaşlayanlar = sehirler.FindAll(s => s.StartsWith("İ"));
			iIleBaşlayanlar.ForEach(x => Console.WriteLine(x));

			// Sort ile sıralama
			Console.WriteLine("\n10. Elemanları Sıralama (Sort):");
			sehirler.Sort();
			sehirler.ForEach(x => Console.WriteLine(x));


			// ForEach ile tüm elemanlara işlem uygulama
			Console.WriteLine("\n11. Tüm Elemanlara İşlem Uygulama (ForEach):");
			sehirler.ForEach(s => Console.WriteLine($"- {s.ToUpper()}"));

			// Clear ile listeyi temizleme
			Console.WriteLine("\n12. Listeyi Temizleme (Clear):");
			sehirler.Clear();
			Console.WriteLine($"Temizleme sonrası eleman sayısı: {sehirler.Count}");

			// Performans örneği
			Console.WriteLine("\n13. Performans Örneği:");
			var sw = Stopwatch.StartNew();

			List<int> numbers = new List<int>();
			for (int i = 0; i < 1000000; i++)
			{
				numbers.Add(i);
			}

			sw.Stop();
			Console.WriteLine($"1.000.000 eleman eklemek: {sw.ElapsedMilliseconds} ms");


		}
		#endregion

		#region 2.Dictionary<TKey, TValue>
		static void DictionaryExample()
		{
			Console.WriteLine("=== Dictionary<TKey, TValue> Örneği ===");
			Console.WriteLine("Dictionary, anahtar-değer çiftleri şeklinde veri saklar. Anahtarlar benzersiz olmalıdır.");

			// Dictionary oluşturma
			Dictionary<string, int> puanlar = new Dictionary<string, int>();

			// Eleman ekleme
			Console.WriteLine("\n1. Eleman Ekleme (Add):");
			puanlar.Add("Ali", 85);
			puanlar.Add("Mehmet", 92);
			puanlar.Add("Ayşe", 78);
			foreach (var puan in puanlar)
			{
				Console.WriteLine($"puan.Key: {puan.Key} - puan.Value : {puan.Value}");
			}


			// İndeksleyici ile eleman ekleme/güncelleme
			Console.WriteLine("\n2. İndeksleyici ile Ekleme/Güncelleme:");
			puanlar["Fatma"] = 88; // Yeni eleman
			puanlar["Ali"] = 90;    // Var olan elemanı güncelleme
			foreach (var puan in puanlar)
			{
				Console.WriteLine($"puan.Key: {puan.Key} - puan.Value : {puan.Value}");
			}

			// ContainsKey ile anahtar varlığını kontrol
			Console.WriteLine("\n3. Anahtar Kontrolü (ContainsKey):");
			Console.WriteLine($"'Mehmet' anahtarı var mı? {puanlar.ContainsKey("Mehmet")}");
			Console.WriteLine($"'Hasan' anahtarı var mı? {puanlar.ContainsKey("Hasan")}");

			// TryGetValue ile güvenli değer alma
			Console.WriteLine("\n4. Güvenli Değer Alma (TryGetValue):");
			if (puanlar.TryGetValue("Ayşe", out int ayşePuan))
			{
				Console.WriteLine($"Ayşe'nin puanı: {ayşePuan}");
			}

			if (!puanlar.TryGetValue("Hasan", out int hasanPuan))
			{
				Console.WriteLine("Hasan bulunamadı.");
			}

			// Keys ve Values koleksiyonları
			Console.WriteLine("\n5. Anahtarlar ve Değerler:");
			Console.WriteLine("Anahtarlar:");
			foreach (var key in puanlar.Keys)
			{
				Console.WriteLine($"- {key}");
			}

			Console.WriteLine("\nDeğerler:");
			foreach (var value in puanlar.Values)
			{
				Console.WriteLine($"- {value}");
			}

			// Remove ile eleman çıkarma
			Console.WriteLine("\n6. Eleman Çıkarma (Remove):");
			puanlar.Remove("Mehmet");
			foreach (var value in puanlar.Values)
			{
				Console.WriteLine($"- {value}");
			}

			//// Filtreleme örneği (LINQ ile)
			//Console.WriteLine("\n7. Filtreleme (LINQ):");
			//var yuksekPuanlar = puanlar.Where(kv => kv.Value >= 85)
			//						  .ToDictionary(kv => kv.Key, kv => kv.Value);
			//PrintDictionary(yuksekPuanlar, "85 ve üzeri puanlar");

			// Clear ile temizleme
			Console.WriteLine("\n8. Sözlüğü Temizleme (Clear):");
			puanlar.Clear();
			Console.WriteLine($"Temizleme sonrası eleman sayısı: {puanlar.Count}");

			//// Farklı tiplerde Dictionary
			//Console.WriteLine("\n9. Farklı Tiplerde Dictionary:");
			//Dictionary<int, string> idToName = new Dictionary<int, string>
			//{
			//	{ 1, "Ali" },
			//	{ 2, "Veli" },
			//	{ 3, "Ayşe" }
			//};

			//PrintDictionary(idToName, "ID-İsim Eşleşmesi");

			//// Anahtarı özel sınıf olan Dictionary
			//Console.WriteLine("\n10. Özel Sınıf Anahtarlı Dictionary:");
			//var kisiBilgileri = new Dictionary<Kisi, string>();

			//var ali = new Kisi { Ad = "Ali", Yas = 30 };
			//var ayse = new Kisi { Ad = "Ayşe", Yas = 25 };

			//kisiBilgileri.Add(ali, "İstanbul'da yaşıyor");
			//kisiBilgileri.Add(ayse, "Ankara'da yaşıyor");

			//// Not: Özel sınıflar anahtar olarak kullanılırken GetHashCode ve Equals metotlarının düzgün implementasyonu önemlidir

			//foreach (var entry in kisiBilgileri)
			//{
			//	Console.WriteLine($"- {entry.Key.Ad} ({entry.Key.Yas}): {entry.Value}");
			//}
		}
		#endregion

		#region 3.ArrayExample
		// 3. Array
		//static void ArrayExample()
		//{
		//	Console.WriteLine("=== Array Örneği ===");
		//	Console.WriteLine("Array (dizi), sabit boyutlu ve her eleman aynı tipte olan bir koleksiyondur.");

		//	// Dizi oluşturma ve başlatma
		//	Console.WriteLine("\n1. Dizi Oluşturma ve Başlatma:");
		//	int[] sayilar = new int[5]; // 5 elemanlı boş dizi
		//	sayilar[0] = 10;
		//	sayilar[1] = 20;
		//	sayilar[2] = 30;
		//	sayilar[3] = 40;
		//	sayilar[4] = 50;

		//	PrintArray(sayilar);

		//	// Başlatıcı liste ile dizi oluşturma
		//	Console.WriteLine("\n2. Başlatıcı Liste ile Dizi Oluşturma:");
		//	string[] meyveler = new string[] { "Elma", "Armut", "Muz", "Kiraz" };
		//	// veya daha kısa şekilde: string[] meyveler = { "Elma", "Armut", "Muz", "Kiraz" };

		//	PrintArray(meyveler);

		//	// İndeks ile erişim
		//	Console.WriteLine("\n3. İndeks ile Erişim:");
		//	Console.WriteLine($"sayilar[2] = {sayilar[2]}");
		//	Console.WriteLine($"meyveler[1] = {meyveler[1]}");

		//	// Length özelliği ile dizi boyutu
		//	Console.WriteLine("\n4. Dizi Boyutu (Length):");
		//	Console.WriteLine($"sayilar dizisinin boyutu: {sayilar.Length}");
		//	Console.WriteLine($"meyveler dizisinin boyutu: {meyveler.Length}");

		//	// IndexOf ile eleman arama
		//	Console.WriteLine("\n5. Eleman Arama (Array.IndexOf):");
		//	int index = Array.IndexOf(meyveler, "Muz");
		//	Console.WriteLine($"'Muz' elemanının indeksi: {index}");

		//	// Dizi kopyalama
		//	Console.WriteLine("\n6. Dizi Kopyalama:");
		//	int[] sayilarKopya = new int[sayilar.Length];
		//	Array.Copy(sayilar, sayilarKopya, sayilar.Length);
		//	PrintArray(sayilarKopya, "Kopyalanan dizi");

		//	// Clone ile dizi kopyalama
		//	Console.WriteLine("\n7. Clone ile Dizi Kopyalama:");
		//	string[] meyvelerKopya = (string[])meyveler.Clone();
		//	PrintArray(meyvelerKopya, "Clone ile kopyalanan dizi");

		//	// Sort ile sıralama
		//	Console.WriteLine("\n8. Diziyi Sıralama (Array.Sort):");
		//	Array.Sort(meyveler);
		//	PrintArray(meyveler, "Sıralanmış meyveler");

		//	// Reverse ile ters çevirme
		//	Console.WriteLine("\n9. Diziyi Ters Çevirme (Array.Reverse):");
		//	Array.Reverse(sayilar);
		//	PrintArray(sayilar, "Ters çevrilmiş sayılar");

		//	// Fill ile diziyi doldurma
		//	Console.WriteLine("\n10. Diziyi Doldurma (Array.Fill):");
		//	int[] doldurulanDizi = new int[5];
		//	Array.Fill(doldurulanDizi, 99);
		//	PrintArray(doldurulanDizi, "99 ile doldurulmuş dizi");

		//	// Çok boyutlu diziler
		//	Console.WriteLine("\n11. Çok Boyutlu Diziler:");

		//	// 2 boyutlu dizi
		//	int[,] matris = new int[3, 2] {
		//		{ 1, 2 },
		//		{ 3, 4 },
		//		{ 5, 6 }
		//	};

		//	Console.WriteLine("2 boyutlu dizi (matris):");
		//	for (int i = 0; i < matris.GetLength(0); i++)
		//	{
		//		for (int j = 0; j < matris.GetLength(1); j++)
		//		{
		//			Console.Write($"{matris[i, j]} ");
		//		}
		//		Console.WriteLine();
		//	}

		//	// Düzensiz diziler (jagged arrays)
		//	Console.WriteLine("\n12. Düzensiz Diziler (Jagged Arrays):");
		//	int[][] düzensizDizi = new int[3][];
		//	düzensizDizi[0] = new int[] { 1, 2 };
		//	düzensizDizi[1] = new int[] { 3, 4, 5, 6 };
		//	düzensizDizi[2] = new int[] { 7, 8, 9 };

		//	Console.WriteLine("Düzensiz dizi:");
		//	for (int i = 0; i < düzensizDizi.Length; i++)
		//	{
		//		for (int j = 0; j < düzensizDizi[i].Length; j++)
		//		{
		//			Console.Write($"{düzensizDizi[i][j]} ");
		//		}
		//		Console.WriteLine();
		//	}

		//	// Performans gösterimi
		//	Console.WriteLine("\n13. Performans Karşılaştırması:");
		//	var sw = Stopwatch.StartNew();

		//	int[] performansDizisi = new int[10000000]; // 10 milyon elemanlı dizi
		//	for (int i = 0; i < performansDizisi.Length; i++)
		//	{
		//		performansDizisi[i] = i;
		//	}

		//	sw.Stop();
		//	Console.WriteLine($"10 milyon elemanlı dizi oluşturma: {sw.ElapsedMilliseconds} ms");

		//	// LINQ ile dizi işlemleri
		//	Console.WriteLine("\n14. LINQ ile Dizi İşlemleri:");
		//	int[] veri = { 5, 12, 8, 3, 15, 7, 10 };

		//	var filtreliVeri = veri.Where(x => x > 7).OrderBy(x => x).ToArray();
		//	PrintArray(filtreliVeri, "7'den büyük ve sıralı sayılar");
		//}

		//// 4. HashSet<T>
		//static void HashSetExample()
		//{
		//	Console.WriteLine("=== HashSet<T> Örneği ===");
		//	Console.WriteLine("HashSet, benzersiz elemanlar içeren ve hızlı arama yapılabilen bir kümedir.");

		//	// HashSet oluşturma
		//	Console.WriteLine("\n1. HashSet Oluşturma:");
		//	HashSet<int> sayilar = new HashSet<int>();

		//	// Eleman ekleme
		//	Console.WriteLine("\n2. Eleman Ekleme (Add):");
		//	sayilar.Add(10);
		//	sayilar.Add(20);
		//	sayilar.Add(30);
		//	sayilar.Add(10); // Tekrar eden eleman - eklenmeyecek

		//	PrintCollection(sayilar);
		//	Console.WriteLine($"Eleman sayısı: {sayilar.Count}"); // 3 olacak, çünkü 10 zaten vardı

		//	// Başlatıcı liste ile oluşturma
		//	Console.WriteLine("\n3. Başlatıcı Liste ile Oluşturma:");
		//	HashSet<string> renkler = new HashSet<string> { "Kırmızı", "Mavi", "Yeşil", "Mavi" }; // Tekrar eden "Mavi" eklenmeyecek
		//	PrintCollection(renkler);

		//	// Contains ile eleman kontrolü
		//	Console.WriteLine("\n4. Eleman Kontrolü (Contains):");
		//	Console.WriteLine($"20 sayısı var mı? {sayilar.Contains(20)}");
		//	Console.WriteLine($"50 sayısı var mı? {sayilar.Contains(50)}");

		//	// Remove ile eleman çıkarma
		//	Console.WriteLine("\n5. Eleman Çıkarma (Remove):");
		//	sayilar.Remove(20);
		//	PrintCollection(sayilar, "20 çıkarıldıktan sonra");

		//	// Clear ile temizleme
		//	Console.WriteLine("\n6. Kümeyi Temizleme (Clear):");
		//	HashSet<int> temizlenecek = new HashSet<int> { 1, 2, 3 };
		//	temizlenecek.Clear();
		//	Console.WriteLine($"Temizleme sonrası eleman sayısı: {temizlenecek.Count}");

		//	// Küme işlemleri
		//	Console.WriteLine("\n7. Küme İşlemleri:");

		//	HashSet<string> kume1 = new HashSet<string> { "A", "B", "C", "D" };
		//	HashSet<string> kume2 = new HashSet<string> { "C", "D", "E", "F" };

		//	// IntersectWith - Kesişim
		//	Console.WriteLine("Kesişim (IntersectWith):");
		//	HashSet<string> kesisim = new HashSet<string>(kume1);
		//	kesisim.IntersectWith(kume2);
		//	PrintCollection(kesisim, "kume1 ∩ kume2");

		//	// UnionWith - Birleşim
		//	Console.WriteLine("\nBirleşim (UnionWith):");
		//	HashSet<string> birlesim = new HashSet<string>(kume1);
		//	birlesim.UnionWith(kume2);
		//	PrintCollection(birlesim, "kume1 ∪ kume2");

		//	// ExceptWith - Fark
		//	Console.WriteLine("\nFark (ExceptWith):");
		//	HashSet<string> fark = new HashSet<string>(kume1);
		//	fark.ExceptWith(kume2);
		//	PrintCollection(fark, "kume1 - kume2");

		//	// SymmetricExceptWith - Simetrik Fark
		//	Console.WriteLine("\nSimetrik Fark (SymmetricExceptWith):");
		//	HashSet<string> simetrikFark = new HashSet<string>(kume1);
		//	simetrikFark.SymmetricExceptWith(kume2);
		//	PrintCollection(simetrikFark, "kume1 △ kume2");

		//	// IsSubsetOf - Alt Küme Kontrolü
		//	Console.WriteLine("\nAlt Küme Kontrolü (IsSubsetOf):");
		//	HashSet<int> anakume = new HashSet<int> { 1, 2, 3, 4, 5 };
		//	HashSet<int> altkume = new HashSet<int> { 2, 3, 4 };
		//	HashSet<int> farklikume = new HashSet<int> { 3, 4, 6 };

		//	Console.WriteLine($"altkume, anakume'nin alt kümesi mi? {altkume.IsSubsetOf(anakume)}");
		//	Console.WriteLine($"farklikume, anakume'nin alt kümesi mi? {farklikume.IsSubsetOf(anakume)}");

		//	// Performans örneği
		//	Console.WriteLine("\n8. Performans Örneği:");
		//	var sw = Stopwatch.StartNew();

		//	HashSet<int> buyukSet = new HashSet<int>();
		//	for (int i = 0; i < 1000000; i++)
		//	{
		//		buyukSet.Add(i);
		//	}

		//	sw.Stop();
		//	Console.WriteLine($"1.000.000 benzersiz eleman ekleme: {sw.ElapsedMilliseconds} ms");

		//	// HashSet vs List arama karşılaştırması
		//	Console.WriteLine("\n9. HashSet vs List Arama Performansı:");

		//	List<int> buyukList = Enumerable.Range(0, 1000000).ToList();

		//	sw.Restart();
		//	bool listSonuc = buyukList.Contains(999999);
		//	sw.Stop();
		//	Console.WriteLine($"List.Contains için geçen süre: {sw.ElapsedMilliseconds} ms");

		//	sw.Restart();
		//	bool hashSetSonuc = buyukSet.Contains(999999);
		//	sw.Stop();
		//	Console.WriteLine($"HashSet.Contains için geçen süre: {sw.ElapsedMilliseconds} ms");
		//}
		#endregion

	}
}