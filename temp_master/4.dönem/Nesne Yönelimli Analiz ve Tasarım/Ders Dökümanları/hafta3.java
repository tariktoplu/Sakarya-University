
import java.util.ArrayList;

public class App {
    public static void main(String[] args) throws Exception {
        Facade.SekilOlustur();
    }
}

public class Creator {
    ArrayList<SekilBase> sekilListesi = new ArrayList<>();
    ArrayList<Double> kurucu = new ArrayList<>();

    private SekilBase SekilOlustur(String sekilTipi, ArrayList<Double> degerler) {

        SekilBase sekil = null;

        switch (sekilTipi) {
            case "Kare" -> {
                sekil = new Kare(degerler.get(0));
            }
            case "Dikdortgen" -> {
                sekil = new Dikdortgen(degerler.get(0), degerler.get(1));
            }
            case "Daire" -> {
                sekil = new Daire(degerler.get(0));
            }
            case "Ucgen" -> {
                sekil = new Ucgen(degerler.get(0), degerler.get(1), degerler.get(2), degerler.get(3));
            }
            case "Yamuk" -> {
                sekil = new Yamuk(degerler.get(0), degerler.get(1), degerler.get(2), degerler.get(3), degerler.get(4));
            }
            default -> {
            }
        }

        return sekil;
    }

    private void SekilEkle() {
        if (sekilListesi == null)
            sekilListesi = new ArrayList<>();
        if (kurucu == null)
            kurucu = new ArrayList<>();

        kurucu.add(5.0);
        sekilListesi.add(SekilOlustur("Kare", kurucu));
        kurucu.clear();

        kurucu.add(10.0);
        sekilListesi.add(SekilOlustur("Kare", kurucu));
        kurucu.clear();

        kurucu.add(5.0);
        kurucu.add(10.0);
        sekilListesi.add(SekilOlustur("Dikdortgen", kurucu));
        kurucu.clear();

        kurucu.add(10.0);
        sekilListesi.add(SekilOlustur("Daire", kurucu));
        kurucu.clear();

        kurucu.add(5.0);
        kurucu.add(10.0);
        kurucu.add(15.0);
        kurucu.add(90.0);
        sekilListesi.add(SekilOlustur("Ucgen", kurucu));
        kurucu.clear();

        kurucu.add(5.0);
        kurucu.add(10.0);
        kurucu.add(15.0);
        kurucu.add(20.0);
        kurucu.add(25.0);
        sekilListesi.add(SekilOlustur("Yamuk", kurucu));
        kurucu.clear();

    }

    public void SekilleriYazdir() {
        SekilEkle();
        for (SekilBase sekil : sekilListesi) {
            sekil.EkranaYazdir();
        }
    }
}

public class Daire extends SekilBase {

    public Daire(double yariCap) {
        super(yariCap);
    }

    @Override
    protected double AlanHesapla() {
        return Math.PI * Math.pow(getUzunluk(), 2);
    }

    @Override
    protected double CevreHesapla() {
        return 2 * Math.PI * getUzunluk();
    }

    @Override
    public void EkranaYazdir() {
        System.out.println("Dairenin Alanı: " + AlanHesapla());
        System.out.println("Dairenin Çevresi: " + CevreHesapla());
    }

}

public class Dikdortgen extends SekilBase {

    private double uzunKenar;

    private double getUzunKenar() {
        return uzunKenar;
    }

    private void setUzunKenar(double uzunKenar) {
        if (uzunKenar <= 0) {
            System.out.println("Uzun kenar 0'dan büyük olmalıdır.");
            this.uzunKenar = 0;
        } else
            this.uzunKenar = uzunKenar;
    }

    public Dikdortgen(double uzunKenar, double kisaKenar) {
        super(kisaKenar);
        this.setUzunKenar(uzunKenar);
    }

    @Override
    protected double AlanHesapla() {
        return getUzunKenar() * getUzunluk();
    }

    @Override
    protected double CevreHesapla() {
        return 2 * (getUzunKenar() + getUzunluk());
    }

    @Override
    public void EkranaYazdir() {
        System.out.println("Dikdörtgenin Alanı: " + AlanHesapla());
        System.out.println("Dikdörtgenin Çevresi: " + CevreHesapla());
    }

}

public class Facade {
    public static void SekilOlustur() {
        Creator creator = new Creator();
        creator.SekilleriYazdir();

    }

}

public class Kare extends SekilBase {

    public Kare(double kenarUzunlugu) {
        super(kenarUzunlugu);

    }

    @Override
    protected double AlanHesapla() {
        return Math.pow(getUzunluk(), 2);
    }

    @Override
    protected double CevreHesapla() {
        return 4 * getUzunluk();
    }

    @Override
    public void EkranaYazdir() {
        System.out.println("Karenin Alanı: " + AlanHesapla());
        System.out.println("Karenin Çevresi: " + CevreHesapla());
    }

}

public abstract class SekilBase {
    protected double uzunluk;

    protected double getUzunluk() {
        return uzunluk;
    }

    protected void setUzunluk(double uzunluk) {
        if (uzunluk <= 0) {
            System.out.println("Uzunluk 0'dan büyük olmalıdır.");
            this.uzunluk = 0;
        } else
            this.uzunluk = uzunluk;
    }

    public SekilBase(double uzunluk) {
        if (uzunluk <= 0) {
            System.out.println("Uzunluk 0'dan büyük olmalıdır.");
            this.uzunluk = 0;
        } else {
            this.uzunluk = uzunluk;
        }
    }

    protected abstract double AlanHesapla();

    protected abstract double CevreHesapla();

    public abstract void EkranaYazdir();

}

public class Ucgen extends SekilBase {
    private double kenar1;
    private double kenar2;
    private double kenar3;

    private double getKenar1() {
        return kenar1;
    }

    private void setKenar1(double kenar1) {
        if (kenar1 <= 0) {
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar1 = 0;
        } else
            this.kenar1 = kenar1;
    }

    private double getKenar2() {
        return kenar2;
    }

    private void setKenar2(double kenar2) {
        if (kenar2 <= 0) {
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar2 = 0;
        } else
            this.kenar2 = kenar2;
    }

    private double getKenar3() {
        return kenar3;
    }

    private void setKenar3(double kenar3) {
        if (kenar3 <= 0) {
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar3 = 0;
        } else
            this.kenar3 = kenar3;
    }

    public Ucgen(double kenar1, double kenar2, double kenar3, double yukseklik) {
        super(yukseklik);
        this.setKenar1(kenar1);
        this.setKenar2(kenar2);
        this.setKenar3(kenar3);
    }

    @Override
    protected double AlanHesapla() {
        return 0.5 * getKenar1() * getUzunluk();
    }

    @Override
    protected double CevreHesapla() {
        return getKenar1() + getKenar2() + getKenar3();
    }

    @Override
    public void EkranaYazdir() {
        System.out.println("Üçgenin Alanı: " + AlanHesapla());
        System.out.println("Üçgenin Çevresi: " + CevreHesapla());
    }

}

public class Yamuk extends SekilBase {

    private double taban;
    private double tavan;
    private double kenar1;
    private double kenar2;

    private double getTaban() {
        return taban;
    }

    private void setTaban(double taban) {
        if (taban <= 0) {
            System.out.println("Taban 0'dan büyük olmalıdır.");
            this.taban = 0;
        } else
            this.taban = taban;
    }

    private double getTavan() {
        return tavan;
    }

    private void setTavan(double tavan) {
        if (tavan <= 0) {
            System.out.println("Tavan 0'dan büyük olmalıdır.");
            this.tavan = 0;
        } else
            this.tavan = tavan;
    }

    private double getKenar1() {
        return kenar1;
    }

    private void setKenar1(double kenar1) {
        if (kenar1 <= 0) {
            System.out.println("Kenar1 0'dan büyük olmalıdır.");
            this.kenar1 = 0;
        } else
            this.kenar1 = kenar1;
    }

    private double getKenar2() {
        return kenar2;
    }

    private void setKenar2(double kenar2) {
        if (kenar2 <= 0) {
            System.out.println("Kenar2 0'dan büyük olmalıdır.");
            this.kenar2 = 0;
        } else
            this.kenar2 = kenar2;
    }

    public Yamuk(double taban, double tavan, double yukseklik, double kenar1, double kenar2) {
        super(yukseklik);
        setTaban(taban);
        setTavan(tavan);
        setKenar1(kenar1);
        setKenar2(kenar2);
    }

    @Override
    protected double AlanHesapla() {
        return (getTaban() + getTavan() * getUzunluk()) / 2;
    }

    @Override
    protected double CevreHesapla() {
        return getTaban() + getTavan() + getKenar1() + getKenar2();
    }

    @Override
    public void EkranaYazdir() {
        System.out.println("Yamuğun Alanı: " + AlanHesapla());
        System.out.println("Yamuğun Çevresi: " + CevreHesapla());
    }

}
