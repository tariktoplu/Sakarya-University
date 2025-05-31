public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Hello, World!");

        Daire daire1=new Daire(5);
        daire1.EkranaYazdir();
        
        Daire daire2=new Daire(10);
        daire2.EkranaYazdir();

        Dikdortgen dikdortgen1=new Dikdortgen(5, 10);
        dikdortgen1.EkranaYazdir();

        Dikdortgen dikdortgen2=new Dikdortgen(8,7);
        dikdortgen2.EkranaYazdir();

        Kare kare1=new Kare(5);
        kare1.EkranaYazdir();

        Ucgen ucgen1=new Ucgen(5, 10, 12, 8);
        ucgen1.EkranaYazdir();

        
        
        
        
    }
}
