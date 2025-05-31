public class Ucgen extends SekilBase {
    private double kenar1;
    private double kenar2;
    private double kenar3;

    private double getKenar1() {
        return kenar1;
    }
    private void setKenar1(double kenar1) {
        if (kenar1<=0){
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar1=0;
        }
        else    
        this.kenar1 = kenar1;
    }

    private double getKenar2() {
        return kenar2;
    }   
    private void setKenar2(double kenar2) {
        if (kenar2<=0){
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar2=0;
        }
        else
        this.kenar2 = kenar2;   
    }

    private double getKenar3() {
        return kenar3;
    }
    private void setKenar3(double kenar3) {
        if (kenar3<=0){
            System.out.println("Kenar 0'dan büyük olmalıdır.");
            this.kenar3=0;
        }
        else
        this.kenar3 = kenar3;
    }   
    public Ucgen(double kenar1, double kenar2, double kenar3,double yukseklik) {
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
