﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarWarsApp.Core.Models;

namespace StarWarsApp
{
    public class FilmDetailsAdapter : BaseAdapter<FilmResult>
    {
        List<FilmResult> _items;
        Activity _context;

        public FilmDetailsAdapter(Activity context, List<FilmResult> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override FilmResult this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.film_details_layout, null);
            view.FindViewById<TextView>(Resource.Id.filmNameTextView).Text = item.title;
            view.FindViewById<TextView>(Resource.Id.filmDetailsTextView1).Text = item.release_date.ToString();
            view.FindViewById<TextView>(Resource.Id.filmDetailsTextView2).Text = item.opening_crawl;


            return view;
        }
    }

    class FilmDetailsAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}