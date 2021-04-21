using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yara.Models.ViewModels;
//https://st.ppapp.ir/1.jpg
namespace Yara.Adapters
{
    class NotificationAdapter : RecyclerView.Adapter
    {
        List<NotificationItel> list = new List<NotificationItel>();
        public NotificationAdapter(List<NotificationItel> List)
        {
            list = List;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.itemNotif, parent, false);
            var vh = new NotificationViewHolder(itemView);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            NotificationViewHolder vh = viewHolder as NotificationViewHolder;

            vh.tvTitel.Text = list[position].Titel;
            vh.tvCaption.Text = list[position].Caption;
            //vh.ivImage.SetImageURI(list[position].ImageSrc);

        }

        public override int ItemCount
        {
            get
            {
                return list.Count;
            }
        }

    }
}