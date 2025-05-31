#ifndef SATIRLISTESIDUGUM_H
#define SATIRLISTESIDUGUM_H

#include "SatirListesi.h"

class SatirListesiDugum
{
	public:
		SatirListesi* sl;
		SatirListesiDugum* sonraki;
		SatirListesiDugum* onceki;
		SatirListesiDugum(SatirListesi*);
};

#endif
