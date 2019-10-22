using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_P2
{
    public class Club
    {
        private ICollection<FigureSkater> _figureSkaters;
        public virtual int ClubId { get; set; }
        public virtual string Name { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual ICollection<FigureSkater> FigureSkaters
        {
            get
            {
                return this._figureSkaters;
            }
            set
            {
                this._figureSkaters = value;
            }
        }

        public virtual void Add(FigureSkater figureSkater)
        {
            //создание списка фигуристов,если его еще не было
            if (_figureSkaters == null)
            {
                _figureSkaters = new List<FigureSkater>();
            }

            //указание id клуба, к котрому принадлежит фигурист
            figureSkater.Club = this;

            //добавление фигуриста в список
            _figureSkaters.Add(figureSkater);
        }

    }
}
