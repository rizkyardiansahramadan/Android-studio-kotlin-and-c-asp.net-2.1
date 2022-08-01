package com.example.latihanjson.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.latihanjson.R
import com.example.latihanjson.model.PostResponse
import kotlinx.android.synthetic.main.item_list.view.*


class PostAdapter (private val list: ArrayList<PostResponse>): RecyclerView.Adapter<PostAdapter.PostViewHolder>(){
    inner class PostViewHolder(itemView: View): RecyclerView.ViewHolder(itemView){
        fun bind(post: PostResponse){
            with(itemView){
                val text = "userId: ${post.userId}\n" +
                        "id: ${post.id}\n" +
                        "title:  ${post.title}\n"
                tvResponse.text = text
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PostViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_list, parent, false)
        return PostViewHolder(view)
    }

    override fun getItemCount(): Int = list.size



    override fun onBindViewHolder(holder: PostAdapter.PostViewHolder, position: Int) {
        holder.bind(list[position])
    }
}
