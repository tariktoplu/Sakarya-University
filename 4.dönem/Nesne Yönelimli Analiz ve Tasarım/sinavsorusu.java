public class Deneme implements IA.IB {

    @Override
    public int Hesapla() {
        // 1 nolu bölge 1 satır kod
        IA.super.Hesapla();
        return 0;
    }

}

public interface IA {
    // 2 nolu bölge

    default public int Hesapla() {
        return 42;
    };
}

public interface IB {
    public int Hesapla();
}
/*
 * yukarıda verilen
 * java kod
 * blogunda IA
 * VE IB
 * interfacelerinde aynı
 * imzaya sahip
 * metodlar
 * diamond
 * problem vardır 1 bolu bölgeyte yazılacak kod ile
 * IA interfaceinin implemasyonunu gerceklestiren kodu yaz
 * java 8 den sonra getirilmiş olan bir anahtar kelime ise 2
 * nolu bölgeye yazılacak (tek bir abahtar kelime)
 */