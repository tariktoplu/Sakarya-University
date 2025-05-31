public class Dikdortgen extends SekilBase {
    
    private double uzunKenar;

    private double getUzunKenar() {
        return uzunKenar;
    }
    private void setUzunKenar(double uzunKenar) {
        if (uzunKenar<=0){
            System.out.println("Uzun kenar 0'dan büyük olmalıdır.");
            this.uzunKenar=0;
        }
        else    
        this.uzunKenar = uzunKenar;
    }

    public Dikdortgen(double uzunKenar, double kisaKenar) {
        super(kisaKenar);
        this.setUzunKenar(uzunKenar);
    }

    @Override
    protected double AlanHesapla() {
        return getUzunKenar() *getUzunluk();
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
