#ifndef YONETICILISTESI_H
#define YONETICILISTESI_H
#include "SatirListesiDugum.h"
#include "SatirListesi.h"

class YoneticiListesi
{
	public:
		int boyut;
		SatirListesiDugum* ilk;
		void ekle(SatirListesi*);
		void sil(SatirListesiDugum*);
		SatirListesiDugum* n_inci_dugum(int);
		void goster();

};

#endif
