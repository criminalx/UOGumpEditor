﻿using UOGumpEditor.Assets;

namespace UOGumpEditor
{
    public class UltimaArtLoader
    {
        public static bool IsLoaded { get; private set; } = false;

        private static readonly Dictionary<int, ArtEntity> GumpArtDict = [];

        private static readonly Dictionary<int, ArtEntity> ItemArtDict = [];

        public static ArtEntity GetArtEntity(int id, bool isGump)
        {
            if (isGump)
            {
                if (GumpArtDict.TryGetValue(id, out ArtEntity? entity))
                {
                    return entity;
                }
            }
            else
            {
                if (ItemArtDict.TryGetValue(id, out ArtEntity? entity))
                {
                    return entity;
                }
            }

            return new ArtEntity(0, "BAD_ART", 0, 0, isGump);
        }

        public UltimaArtLoader()
        {
            if (!string.IsNullOrEmpty(UOSettings.Default.UO_Folder))
            {
                AssetData.Load(UOSettings.Default.UO_Folder, "enu", true);

                IsLoaded = true;
            }
            else
            {
                MessageBox.Show("UO Directory Missing!", "Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void ClearArt()
        {
            AssetData.Clear();
        }

        public static async Task LoadAllGumpArtAsync()
        {
            if (IsLoaded && AssetData.Gumps != null)
            {
                await Task.Run(() =>
                {
                    Bitmap? gump;

                    for (int i = 0; i < AssetData.Gumps.Length; i++)
                    {
                        gump = AssetData.Gumps.GetGump(i);

                        if (gump != null)
                        {
                            lock (GumpArtDict)
                            {
                                GumpArtDict[i] = new ArtEntity(i, GetGumpName(i), gump.Width, gump.Height, true);
                            }

                            gump.Dispose();

                            gump = null;
                        }
                        else
                        {
                            lock (GumpArtDict)
                            {
                                GumpArtDict[i] = new ArtEntity(i, "FREE_SLOT", 0, 0, true);
                            }
                        }
                    }
                });
            }
        }

        public static async Task LoadAllItemArtAsync()
        {
            if (IsLoaded && AssetData.Art != null)
            {
                await Task.Run(() =>
                {
                    Bitmap? item;

                    for (int i = 0; i < AssetData.Art.MaxItemID; i++)
                    {
                        item = AssetData.Art.GetStatic(i);

                        if (item != null)
                        {
                            lock (ItemArtDict)
                            {
                                ArtEntity entity = new(i, GetItemName(i), item.Width, item.Height, false);

                                AssetData.Art.Measure(item, out int minX, out int maxX, out int minY, out int maxY);

                                entity.SetRawSizes(maxX - minX, maxY - minY);

                                ItemArtDict[i] = entity;
                            }

                            item.Dispose();

                            item = null;
                        }
                        else
                        {
                            lock (ItemArtDict)
                            {
                                ItemArtDict[i] = new ArtEntity(i, "FREE_SLOT", 0, 0, false);
                            }
                        }
                    }
                });
            }
        }

        private static string GetGumpName(int i)
        {
            // Get Element Name for Art : ie: Button

            return $"Gump_{i}";
        }

        private static string cachedName = "";

        private static string GetItemName(int i)
        {
            cachedName = AssetData.Tiles.ItemTable[i].Name;

            if (string.IsNullOrEmpty(cachedName))
            {
                return "NO_NAME";
            }
            else
            {
                return cachedName;
            }
        }

        private static List<ArtEntity>? tempEntityList;

        public static bool SearchArtByID(int id, bool isGump, out List<ArtEntity> list)
        {
            int range = UOSettings.Default.DisplayMax / 2;

            if (id - range < 0)
            {
                range = id;
            }

            if (isGump)
            {
                if (id + range >= GumpArtDict.Count)
                {
                    range = Math.Abs(GumpArtDict.Count - id);
                }

                tempEntityList = GumpArtDict.Values.Where(a => a.ID <= id + range && a.ID >= id - range).ToList();

                return LoadList(tempEntityList, out list);
            }
            else
            {
                if (id + range >= ItemArtDict.Count)
                {
                    range = Math.Abs(ItemArtDict.Count - id);
                }

                tempEntityList = ItemArtDict.Values.Where(a => a.ID < id + range && a.ID > id - range).ToList();

                return LoadList(tempEntityList, out list);
            }
        }

        public static bool SearchArtByName(string name, bool isGump, out List<ArtEntity> list)
        {
            if (isGump)
            {
                tempEntityList = GumpArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(tempEntityList, out list);
            }
            else
            {
                tempEntityList = ItemArtDict.Values.Where(a => a.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return LoadList(tempEntityList, out list);
            }
        }

        public static bool SearchArtBySize(int size, bool isGump, out List<ArtEntity> list, bool isWidth)
        {
            if (isGump)
            {
                if (isWidth)
                {
                    tempEntityList = GumpArtDict.Values.Where(a => a.Width == size).ToList();
                }
                else
                {
                    tempEntityList = GumpArtDict.Values.Where(a => a.Height == size).ToList();
                }

                return LoadList(tempEntityList, out list);
            }
            else
            {
                if (isWidth)
                {
                    tempEntityList = ItemArtDict.Values.Where(a => a.RawWidth == size).ToList();
                }
                else
                {
                    tempEntityList = ItemArtDict.Values.Where(a => a.RawHeight == size).ToList();
                }

                return LoadList(tempEntityList, out list);
            }
        }

        private static bool LoadList(List<ArtEntity> itemList, out List<ArtEntity> list )
        {
            if (itemList != null && itemList.Count > 0)
            {
                if (itemList.Count > UOSettings.Default.DisplayMax)
                {
                    list = itemList.GetRange(0, UOSettings.Default.DisplayMax);
                }
                else
                {
                    list = itemList;
                }

                return true;
            }

            list = [];

            return false;
        }
    }
}
