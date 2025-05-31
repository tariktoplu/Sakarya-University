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
