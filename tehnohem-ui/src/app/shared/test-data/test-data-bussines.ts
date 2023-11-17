import { Company } from "../model/company"
import { CompanyType } from "../model/enums/companyType"
import { Expenses } from "../model/expenses"

export const dugovanja: Expenses[]=[
    {
      customer:"Tisal d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"126/23",
      date:"17.12.2023",
      total_price:2686.13
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"623/23",
      date:"02.12.2023",
      total_price:460.79
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"745/23",
      date:"26.12.2023",
      total_price:1396.30
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
    {
      customer:"EZ d.o.o.",
      invoice_id:"126/23",
      date:"17.12.2023",
      total_price:2686.13
    },
    {
      customer:"EZ d.o.o.",
      invoice_id:"623/23",
      date:"02.12.2023",
      total_price:460.79
    },
    {
      customer:"EZ d.o.o.",
      invoice_id:"745/23",
      date:"26.12.2023",
      total_price:1396.30
    },
    {
      customer:"EZ d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
    {
      customer:"JocHem d.o.o.",
      invoice_id:"126/23",
      date:"17.12.2023",
      total_price:2686.13
    },
    {
      customer:"JocHem d.o.o.",
      invoice_id:"623/23",
      date:"02.12.2023",
      total_price:460.79
    },
    {
      customer:"JocHem d.o.o.",
      invoice_id:"745/23",
      date:"26.12.2023",
      total_price:1396.30
    },
    {
      customer:"JocHem d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
    {
      customer:"Tehicka d.o.o.",
      invoice_id:"126/23",
      date:"17.12.2023",
      total_price:2686.13
    },
    {
      customer:"Tehicka d.o.o.",
      invoice_id:"623/23",
      date:"02.12.2023",
      total_price:460.79
    },
    {
      customer:"Tehicka d.o.o.",
      invoice_id:"745/23",
      date:"26.12.2023",
      total_price:1396.30
    }
  ]
  export const uplate: Expenses[]=[
    {
      customer:"Tehicka d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
    {
      customer:"Tehicka d.o.o.",
      invoice_id:"126/23",
      date:"17.12.2023",
      total_price:2686.13
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"623/23",
      date:"02.12.2023",
      total_price:460.79
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"745/23",
      date:"26.12.2023",
      total_price:1396.30
    },
    {
      customer:"Tisal d.o.o.",
      invoice_id:"123/23",
      date:"12.12.2023",
      total_price:996.51
    },
  ]
export const getters : Company[]=[
    {
      id:"1",
      name:"Tisal d.o.o.",
      address:"Busovaca, Tuzlanska 14",
      jib:"1235324242",
      ib:"2131313",
      phoneNumber:"0659138923",
      email: "email@gmail.com",
      companyType: CompanyType.SUPPLIER,
      contactPerson:"Milos Zivanovic",
      headCompanyId:"1"
    },
    {
      id:"1",
      name:"EZ d.o.o.",
      address:"Ugljevik, Mali Trg 13",
      jib:"1235324242",
      ib:"2131313",
      phoneNumber:"0659138923",
      email: "email@gmail.com",
      companyType: CompanyType.SUPPLIER,
      contactPerson:"Milos Zivanovic",
      headCompanyId:"1"
    },
    {
      id:"1",
      name:"Tehicka d.o.o.",
      address:"Sarajevo, Marsala Tite 65",
      jib:"1235324242",
      ib:"2131313",
      phoneNumber:"0659138923",
      email: "email@gmail.com",
      companyType: CompanyType.SUPPLIER,
      contactPerson:"Milos Zivanovic",
      headCompanyId:"1"
    },
    {
      id:"1",
      name:"JocHem d.o.o.",
      address:"Tuzla , malozvornicka 98",
      jib:"1235324242",
      ib:"2131313",
      phoneNumber:"0659138923",
      email: "email@gmail.com",
      companyType: CompanyType.SUPPLIER,
      contactPerson:"Milos Zivanovic",
      headCompanyId:"1"
    }
  ]

export const thirdFaces:Company[]=[
  {
    id:"1",
    name:"Miroslav Dronjak",
    address:"Zvornik, grobnice 15",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.THIRD_PARTY,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"Elektrodistribucija",
    address:"Sarajevo, dsakndsaj 21",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.THIRD_PARTY,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"Ivan Dikin",
    address:"Zvornik, Meterize bb",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.THIRD_PARTY,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"Knjizara Sale",
    address:"Bijeljina, dsakndsaj 21",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.THIRD_PARTY,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
]


export const dugovanjaOstala: Expenses[]=[
  {
    customer:"Ivan Dikin",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Ivan Dikin",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Ivan Dikin",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Miroslav Dronjak",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Miroslav Dronjak",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Ivan Dikin",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Miroslav Dronjak",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  }
]


export const uplateOstalo: Expenses[]=[
  {
    customer:"Miroslav Dronjak",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Elektrodistrbucija",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Ivan Dikin",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Miroslav Dronjak",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Elektrodistribucija",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
]

export const customers : Company[]=[
  {
    id:"1",
    name:"Zvornicanka d.o.o.",
    address:"Busovaca, Tuzlanska 14",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.CUSTOMER,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"Beoprom d.o.o.",
    address:"Ugljevik, Mali Trg 13",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.CUSTOMER,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"Boksit Milici d.o.o.",
    address:"Sarajevo, Marsala Tite 65",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.CUSTOMER,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  },
  {
    id:"1",
    name:"M&V group",
    address:"Tuzla , malozvornicka 98",
    jib:"1235324242",
    ib:"2131313",
    phoneNumber:"0659138923",
    email: "email@gmail.com",
    companyType: CompanyType.CUSTOMER,
    contactPerson:"Milos Zivanovic",
    headCompanyId:"1"
  }
]

export const izlazneFakture: Expenses[]=[
  {
    customer:"Zvornicanka d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Zvornicanka d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"M&V group",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Zvornicanka d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Zvornicanka d.o.o.",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Zvornicanka d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"M&V group",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"M&V group",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"M&V group",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"M&V group",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  }
]


export const uplateKupci: Expenses[]=[
  {
    customer:"M&V group",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"M&V group",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"M&V group",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"M&V group",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
  {
    customer:"M&V group",
    invoice_id:"123/23",
    date:"12.12.2023",
    total_price:996.51
  },
  {
    customer:"Boksit Milici d.o.o.",
    invoice_id:"126/23",
    date:"17.12.2023",
    total_price:2686.13
  },
  {
    customer:"Beoprom d.o.o.",
    invoice_id:"623/23",
    date:"02.12.2023",
    total_price:460.79
  },
  {
    customer:"M&V group",
    invoice_id:"745/23",
    date:"26.12.2023",
    total_price:1396.30
  },
]