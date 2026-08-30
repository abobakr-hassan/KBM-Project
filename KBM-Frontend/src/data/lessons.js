export const lessons = [
  {
    id: 1,
    category: "BEST PRACTICE",
    categoryType: "blue",
    title: "Optimizing PLC Logic for High-Speed Packaging",
    author: "Hassan El-Sayed",
    role: "Automation Engineer",
    department: "Automation Engineering",
    personToContact: "Hassan El-Sayed",
    projectName: "Packaging Line Upgrade",
    industry: "Manufacturing",
    rating: 4.5,
    reviews: 13,
    image: "https://placehold.co/600x350/1769aa/ffffff?text=PLC+Logic",
    description:
      "Refined PLC logic to reduce cycle times on a high-speed packaging line. The team moved task priorities and interrupt routines away from sequential polling toward event-driven execution, cutting idle time between cycles.",
    valueProposition:
      "A detailed guide on refining PLC logic to reduce cycle times in high-speed packaging lines by 15%.",
    keywords: ["automation", "PLC", "packaging"],
    attachments: [
      { name: "PLC_Logic_Specs.pdf", size: "2.4 MB", type: "PDF" }
    ],
    quickLinks: [{ label: "Internal Wiki - Automation", url: "#" }]
  },
  {
    id: 2,
    category: "ENGINEERING",
    categoryType: "orange",
    title: "Standardizing Wiring Diagrams for Global Clients",
    author: "Youssef Hany",
    role: "Electrical Engineer",
    department: "Electrical Engineering",
    personToContact: "Youssef Hany",
    projectName: "Global Client Rollout",
    industry: "Manufacturing",
    rating: 5,
    reviews: 24,
    image: "https://placehold.co/600x350/c87500/ffffff?text=Wiring+Diagram",
    description:
      "Introduced a single wiring diagram standard used across every regional office, replacing five inconsistent formats. Diagrams now share a common symbol set, labeling convention, and revision history block.",
    valueProposition:
      "A shared wiring diagram standard that cut cross-team review time in half and eliminated translation errors between regional offices.",
    keywords: ["electrical", "standards", "documentation"],
    attachments: [
      { name: "Wiring_Standard_v2.docx", size: "1.1 MB", type: "DOCX" }
    ],
    quickLinks: [{ label: "Internal Wiki - Electrical", url: "#" }]
  },
  {
    id: 3,
    category: "BEST PRACTICE",
    categoryType: "green",
    title: "Improving Operator UX in Challenging Environments",
    author: "Sarah Ahmed",
    role: "Automation Engineer",
    department: "Automation Engineering",
    personToContact: "Sarah Ahmed",
    projectName: "Automation Solutions Phase 2",
    industry: "Manufacturing",
    rating: 4.5,
    reviews: 8,
    image: "https://placehold.co/600x350/00a878/ffffff?text=Operator+UX",
    description:
      "Documented the specific logic adjustments made to the high-speed sorting system. Covers the transition from traditional sequential processing to event-driven execution, significantly reducing idle time between cycles. Key technical steps include optimizing task priorities and implementing high-speed interrupt routines for sensor feedback, adjusting the task cycle time from 10ms to a variable execution model based on sensor triggers.",
    valueProposition:
      "A detailed guide on refining PLC logic to reduce cycle times in high-speed packaging lines by 15%.",
    keywords: ["automation", "PLC", "packaging"],
    attachments: [
      { name: "PLC_Logic_Specs.pdf", size: "2.4 MB", type: "PDF" }
    ],
    quickLinks: [{ label: "Internal Wiki - Automation", url: "#" }]
  }
];
