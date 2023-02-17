using MySql.Data.MySqlClient;
using System.Linq;
namespace PlayList.Models
{
    public class StoreContext
    {
        MusicDataContext db = new MusicDataContext();
        public StoreContext()
        {

        }
        public bool InsertBaiHat(BaiHat bh)
        {
            MusicDataContext db = new MusicDataContext();

            try
            {

                db.BaiHat.Add(bh);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public List<CaSi> GetCaSis(DateTime ns)
        {
            MusicDataContext db = new MusicDataContext();
            List<CaSi> casis = new List<CaSi>();
            CaSi tem = new CaSi();
            var CaSis = db.CaSi.Where(x => x.NamSinh == ns);
            foreach (var casi in CaSis)
            {
                tem = new CaSi();
                tem.MaCaSi = casi.MaCaSi;
                tem.TenCaSi = casi.TenCaSi;
                tem.GioiTinh = casi.GioiTinh;
                tem.NamSinh = casi.NamSinh;

                casis.Add(tem);
            }
            return casis;
        }
        public List<NguoiNghe> GetNNs()
        {
            MusicDataContext db = new MusicDataContext();
            List<NguoiNghe> nns = new List<NguoiNghe>();
            NguoiNghe tem = new NguoiNghe();

            foreach (var d in db.NguoiNghe)
            {
                tem = new NguoiNghe();
                tem.MaNN = d.MaNN;
                tem.TenNN = d.TenNN;
                tem.GioiTinh = d.GioiTinh;
                nns.Add(tem);
            }
            return nns;
        }
        public List<PlayList> GetPlayList(String MaNN)
        {
            MusicDataContext db = new MusicDataContext();
            List<PlayList> pl = new List<PlayList>();
            PlayList tem = new PlayList();
            var playlist = db.PlayList.Where(x => x.MaNN == MaNN);
            foreach (var d in playlist)
            {
                tem = new PlayList();
                tem.MaPlayList = d.MaPlayList;
                tem.SoLuong = d.SoLuong;
                tem.TenPlayList = d.TenPlayList;
                tem.MaNN = d.MaNN;
                pl.Add(tem);
            }
            return pl;
        }
        public bool DeletePlayList(string id)
        {
            using (MusicDataContext db = new MusicDataContext())
            {
                try
                {
                    var plbh = db.PlayList_BaiHat.Where(x => x.MaPlayList == id);
                    db.PlayList_BaiHat.RemoveRange(plbh);
                    db.SaveChanges();

                    var pl = db.PlayList.Where(x => x.MaPlayList == id);
                    db.PlayList.RemoveRange(pl);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public List<PlayListViewModel> ViewPlayList(string MaPL)
        {
            List<PlayListViewModel> pl = new List<PlayListViewModel>();
            PlayListViewModel tem = new PlayListViewModel();
            var playlist = db.PlayList_BaiHat.Join(db.CaSi_BaiHat, x => x.MaBaiHat, y => y.MaBaiHat, (x, y) => new { x.MaBaiHat, y.MaCaSi, x.MaPlayList }).
                            Join(db.BaiHat, xy => xy.MaBaiHat, bh => bh.MaBaiHat, (xy, bh) => new { xy.MaBaiHat, xy.MaCaSi, xy.MaPlayList, bh.TenBaiHat }).
                            Join(db.CaSi, bh => bh.MaCaSi, cs => cs.MaCaSi, (bh, cs) => new { bh.TenBaiHat, cs.TenCaSi, bh.MaPlayList });

            foreach (var d in playlist.Where(x => x.MaPlayList == MaPL))
            {
                tem = new PlayListViewModel();
                tem.MaPlayList = d.MaPlayList;
                tem.TenBaiHat = d.TenBaiHat;
                tem.TenCaSi = d.TenCaSi;
                pl.Add(tem);
            }
            return pl;
        }

    }
}