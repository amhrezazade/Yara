using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Yara.Data;
using AndroidX.CardView.Widget;
using AndroidX.AppCompat.View.Menu;

namespace Yara.Adapters
{

    public class NotificationViewHolder : RecyclerView.ViewHolder
    {
        public TextView tvTitel{ get; set; }

        public TextView tvCaption { get; set; }

        public ImageView ivImage { get; set; }

        public NotificationViewHolder(View itemView) : base(itemView)
        {
            tvTitel = (TextView)itemView.FindViewById(Resource.Id.tvTitle);
            tvCaption = (TextView)itemView.FindViewById(Resource.Id.tvDes);
            ivImage = (ImageView)itemView.FindViewById(Resource.Id.ivImageNotification);
        }
    }
}