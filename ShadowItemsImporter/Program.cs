using System;
using System.Collections.Generic;
using DynamicFilter.Domain.Core.Models;
using DynamicFilter.MongoDb;
using MongoDB.Bson;
using Attribute = DynamicFilter.Domain.Core.Models.Attribute;

namespace ShadowItemsImporter {
    class Program {
        static void Main() {
            var items = new List<Item>();

            items.Add(new Item {
                Name = "Plant Simulation",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.simplan.de/wp-content/uploads/2019/05/SimPlan-Logo_80-205x80-1.png",
                Description = "Optimierung von Produktionssystemen",
                WebsiteUrl = "https://www.simplan.de/software/plant-simulation/"
            });
            items.Add(new Item {
                Name = "Automod",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://automod.de/wp-content/uploads/logo_automod_simplan.png",
                Description = "Diskrete Ereignissimulation zur Verbesserung, Konfigurierung  und Optimierung von Materialflussystemen",
                WebsiteUrl = "https://automod.de/"
            });
            items.Add(new Item {
                Name = "visTABLE®touch",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.vistable.de/wp-content/uploads/2018/04/vistable-logo-small-white.png",
                Description = "Optemieren, bewerten und visualisieren einer Fabrik. Szenarienplanung, Anpassungsmanagement",
                WebsiteUrl = "https://www.vistable.de/software/"
            });
            items.Add(new Item {
                Name = "Fabrikplanungs-PPT 4.0.1",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.total-e-quality.de/media/cache/dd/ae/ddaeab2fea73f568f4300a01f2f4a124.jpg",
                Description = "Layoutplanung einer Fabrik. Materialflüsse optimieren",
                WebsiteUrl = "https://www.heise.de/download/product/fabrikplanungs-ppt-61214"
            });
            items.Add(new Item {
                Name = "Fastsuite 2",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "http://www.cenit.com/fileadmin/ittag/img/cenit_Logo.png",
                Description = "Optimierung von Produktionssystemen. Automatisierungsprozesse von Roboter und Montage",
                WebsiteUrl = "http://www.cenit.com/de_DE/metanavi/kontakt.html"
            });
            items.Add(new Item {
                Name = "Autodesk Factory Design Suite",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.2ndsoft.de/shop/images/product_images/popup_images/a6160.jpg",
                Description = "Generierung synchronisierter digitaler 2D- und 3D-Pläne, planen und prüfen, um Ihre Arbeitsabläufe zu straffen und die Anlagen optimal zu platzieren",
                WebsiteUrl = "https://www.autodesk.de/suites/factory-design-suite/overview"
            });
            items.Add(new Item {
                Name = "Wirthsim Professional",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://wirthsim.com/files/theme-src/images/logo/WirthSim_Logo.png",
                Description = "Simulation von Transportwegen, Materialflussplanung 2D und 3D Gestaltung",
                WebsiteUrl = "https://wirthsim.com/"
            });
            items.Add(new Item {
                Name = "taraVRbuilder",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.tarakos.de/images/beitragsbilder/taravrbuilder-2019.jpg",
                Description = "Einfache und schnelle 3D-Visualisierung für Logistik, Fabrik-, Materialflussplanung",
                WebsiteUrl = "https://www.tarakos.de/taravrbuilder.html"
            });
            items.Add(new Item {
                Name = "Simens NX",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://seeklogo.com/images/S/siemens-nx-plm-logo-75A9A37993-seeklogo.com.png",
                Description = "Design-, Simulations- und Fertigungslösungen",
                WebsiteUrl = "https://www.pbu-cad.de/software/cad/siemens-nx?gclid=CjwKCAiA1rPyBRAREiwA1UIy8CUJDCnCzt8dqG6Jidsw0zImRe9pTBwnQWGBcBgvzOA-S6WZcXrHZBoCcOEQAvD_BwE"
            });
            items.Add(new Item {
                Name = "Dassault Systèmes Catia ",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.3ds.com/statics/menu/2/assets/img/logo/3ds-dark.svg",
                Description = "Konstruktions-, Engineering-, Systementwicklungs- und Bauanwendungen",
                WebsiteUrl = "https://www.3ds.com/de/produkte-und-services/catia/"
            });
            items.Add(new Item {
                Name = "Dassault Systèmes DELMIA ",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.3ds.com/statics/menu/2/assets/img/logo/3ds-dark.svg",
                Description = "Modellierung, Optimierung und Ausführung ihrer Prozesse",
                WebsiteUrl = "https://www.3ds.com/de/produkte-und-services/delmia/"
            });
            items.Add(new Item {
                Name = "Siemens Solid Edge 2020",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQLhXPZSP0sGvL6h5szzba7ETWqxhgBwlX4BNYu8yLcnuaiLjTL",
                Description = "vollständige Digitalisierung des Prozesses von der Konstruktion bis zur Fertigung",
                WebsiteUrl = "https://solidedge.siemens.com/de/"
            });
            items.Add(new Item {
                Name = "M4plant",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://i.ytimg.com/vi/UOpr6V2Cldw/maxresdefault.jpg",
                Description = "Größenunabhängige Layout kompletter Gebäude und Produktionsanlagen",
                WebsiteUrl = "https://www.cad-schroer.de/produkte/m4-plant/"
            });
            items.Add(new Item {
                Name = "Open Factory 3D",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.total-e-quality.de/media/cache/dd/ae/ddaeab2fea73f568f4300a01f2f4a124.jpg",
                Description = "Maschinen und Werksausrüstungen mit einer 3D-Vorschau auf einem 2D-Werksplan platzieren",
                WebsiteUrl = "https://open-factory-3d.soft112.com/"
            });
            items.Add(new Item {
                Name = "VISUAL COMPONENTS 4.2 Premium",
                Attributes = new List<Attribute>(),
                AttributeGroups = new List<AttributeGroup>(new List<AttributeGroup>{
                    new AttributeGroup {
                        Name = "Hauptanwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Fabrikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Produktionsplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Gebäudeplanung/ Architektur/ Baukonstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "(Prozess-) Optimierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Anlagenplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }

                        }
                    },
                    new AttributeGroup {
                        Name = "Darstellung",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "2D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "3D",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "VR",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Simulation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Animation",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Modellierung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "CAD",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "BIM",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Typische Anwendungsbereiche",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Layoutplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Materialflussplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Logistikplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Werkstrukturplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Lagerplanung",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Konstruktion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Datenmanagement",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Betriebssysteme",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Windows XP",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows Vista",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 7",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Windows 8",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Windows 10",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Unix",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "MacOS",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            }
                        }
                    },
                    new AttributeGroup {
                        Name = "Kosten & Lizenzumfang",
                        Attributes = new List<Attribute> {
                            new Attribute {
                                Name = "Kostenpflichtig",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            },
                            new Attribute {
                                Name = "Kostenlos für Studenten",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "false"
                            },
                            new Attribute {
                                Name = "Testversion",
                                Weight = 1,
                                Type = AttributeType.Bool,
                                Value = "true"
                            }
                        }
                    }
                }),
                Id = ObjectId.GenerateNewId(),
                IconUrl = "https://www.visualcomponents.com/wp-content/themes/vc-new/images/vc_logo.png",
                Description = "moderne 3D-Fertigungssimulationsanwendungen, Prozessmodellierung, Einfache Roboterprogrammierung",
                WebsiteUrl = "https://www.visualcomponents.com/de/produkte/visual-components/"
            });

            MongoDb.Connect("mongodb+srv://dynamicfilter:LJSMC_58542@dynamicfiltercluster-6dumn.gcp.mongodb.net/test?retryWrites=true&w=majority");

            MongoDb.Save(items);
            Console.WriteLine("Items Saved");
            Console.ReadKey();
        }
    }
}
