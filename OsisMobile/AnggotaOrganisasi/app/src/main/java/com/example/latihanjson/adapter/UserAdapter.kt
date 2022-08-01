package com.example.latihanjson.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.latihanjson.R
import com.example.latihanjson.model.User
import kotlinx.android.synthetic.main.item_list.view.*


class UserAdapter (private val list: ArrayList<User>): RecyclerView.Adapter<UserAdapter.UserViewHolder>(){
    inner class UserViewHolder(itemView: View): RecyclerView.ViewHolder(itemView) {
        fun bind(user: User){
            with(itemView){
                var text = "id: ${user.id}\n" +
                        "nim: ${user.nim}\n" +
                        "nama: ${user.nama}\n" +
                        "kelas: ${user.kelas}\n" +
                        "jabatan: ${user.jabatan}"

                tvResponse.text = text
                }
            }
        }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UserAdapter.UserViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_list, parent, false)
        return UserViewHolder(view)
    }
    override fun getItemCount(): Int = list.size

    override fun onBindViewHolder(holder: UserViewHolder, position: Int) {
        holder.bind(list[position])
    }
}

