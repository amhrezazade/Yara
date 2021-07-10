using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Yara.Models.ViewModels;
using Yara.Service;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using AndroidX.CardView.Widget;
using AndroidX.AppCompat.View.Menu;
using Yara.Adapters;
using Yara.Activity;

namespace Yara.Adapters
{

    public class ContentItemViewHolder : RecyclerView.ViewHolder
    {
        public View Item { get; }
        public TextView tvTitel { get; }
        public TextView tvCaption { get; }
        public TextView tvDate { get;}
        public TextView tvN1 { get; }
        public TextView tvN2 { get; }
        public TextView tvdef { get; }
        public Button btLink { get;}
        public ImageView ivImage { get; }
        public ImageView ivShareImage { get; }
        public ContentItemViewHolder(View itemView) : base(itemView)
        {           
            Item = itemView.FindViewById(Resource.Id.ContentItemView);
            tvDate = (TextView)itemView.FindViewById(Resource.Id.tvDateTime);
            tvN1 = (TextView)itemView.FindViewById(Resource.Id.tvNote1);
            tvN2 = (TextView)itemView.FindViewById(Resource.Id.tvNote2);
            tvdef = (TextView)itemView.FindViewById(Resource.Id.tvdefinerContentItem);
            btLink = (Button)itemView.FindViewById(Resource.Id.btnFileContent);
            tvTitel = (TextView)itemView.FindViewById(Resource.Id.tvTitleContent);
            tvCaption = (TextView)itemView.FindViewById(Resource.Id.tvDesContent);
            ivImage = (ImageView)itemView.FindViewById(Resource.Id.ivImageContent);
            ivShareImage = (ImageView)itemView.FindViewById(Resource.Id.ivImageShareContent);
        }
    }

    public class ContentItemAdapter : RecyclerView.Adapter
    {
        ContentItem[] Items;

        public ContentItemAdapter(ContentItem[] List)
        {
            Items = List;
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
            new ContentItemViewHolder(LayoutInflater.From(parent.Context).Inflate(Resource.Layout.itemContent, parent, false));



        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ContentItemViewHolder vh = viewHolder as ContentItemViewHolder;
            ContentItem item = Items[position];


            vh.tvTitel.Text = item.Titel;
            vh.tvCaption.Text = item.Caption;
            vh.tvDate.Text = item.date;
            vh.tvN1.Text = item.GreenNote;
            vh.tvN2.Text = item.RedNote;
            vh.tvdef.Text = item.Def;


            if(item.date == "")
            {
                vh.ivShareImage.Visibility = ViewStates.Invisible;
            }
                
            else
            {
                vh.ivShareImage.Visibility = ViewStates.Visible;
            }
                


            if (item.Link == "")
            {
                vh.btLink.Visibility = ViewStates.Invisible;
            }
            else
            {
                vh.btLink.Visibility = ViewStates.Visible;
                vh.btLink.Text = item.LinkTitel;
                vh.btLink.Click += async (s, e) =>
                {
                    await Browser.OpenAsync(item.Link, BrowserLaunchMode.SystemPreferred);
                };
            }


            vh.ivShareImage.Click += async (s, e) =>
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = item.getShareText(),
                    Title = "Share Item"
                });
            };

            if(item.Image == Models.ImageType.Subject)
                vh.Item.SetBackgroundColor(Color.Black);
            else
                vh.Item.SetBackgroundColor(Color.Rgb(30, 30, 30));

            switch (item.Image)
            {
                case Models.ImageType.Motif:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_notif);
                    if(item.RedNote == "جدید")
                    {
                        Task.Run(() =>
                        {
                            Api.SeenAnnounce(int.Parse(item.Def));
                        });
                        vh.Item.SetBackgroundColor(Color.Rgb(60,0,80));
                    }
                    break;
                case Models.ImageType.Cloud:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_cloud);
                    break;
                case Models.ImageType.Note:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_note);
                    break;
                case Models.ImageType.Person:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.Item.Click += async (s, e) =>
                    {
                        var co = Application.Context;
                        var intent = new Intent(co, typeof(MessageActivity));
                        intent.PutExtra("arg", item.Def);
                        co.StartActivity(intent);
                    };
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_baseline_person_24);
                    break;
                case Models.ImageType.Subject:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_subject);
                    break;
                case Models.ImageType.exam:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_exam);
                    break;
                case Models.ImageType.mail:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    vh.ivImage.SetImageResource(Resource.Drawable.ic_mail);
                    break;
                case Models.ImageType.Profile:
                    vh.ivImage.Visibility = ViewStates.Visible;
                    try
                    {
                        vh.ivImage.SetImageBitmap(db.LoadProfileImage());
                    }
                    catch
                    {
                        vh.ivImage.SetImageResource(Resource.Drawable.ic_baseline_person_24);
                    }
                    break;
                default:
                    vh.ivImage.Visibility = ViewStates.Invisible;
                    vh.Item.SetBackgroundColor(Color.Black);
                    break;



            }


        }

        public override int ItemCount
        {
            get
            {
                return Items.Length;
            }
        }

    }
}