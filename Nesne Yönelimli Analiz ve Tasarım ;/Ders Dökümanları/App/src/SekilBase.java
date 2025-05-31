public abstract class SekilBase {
    protected double uzunluk;

    protected double getUzunluk() {
        return uzunluk;
    }
    protected void setUzunluk(double uzunluk) {
        if (uzunluk<=0){
            System.out.println("Uzunluk 0'dan büyük olmalıdır.");
            this.uzunluk=0;
        }
        else    
        this.uzunluk = uzunluk;
    }

    public SekilBase(double uzunluk) {
        this.setUzunluk(uzunluk);
    }

    protected abstract double AlanHesapla();

    protected double CevreHesapla()
    {
        ///kodları burada yazılacak
        return 0;
    }

    public void EkranaYazdir()
    {
       //kodlar buraya gelecek;
    }

    
}
