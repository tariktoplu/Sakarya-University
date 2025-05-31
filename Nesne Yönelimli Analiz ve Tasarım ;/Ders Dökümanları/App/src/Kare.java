public class Kare extends SekilBase {
    
    public Kare(double kenarUzunlugu)
    {
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

