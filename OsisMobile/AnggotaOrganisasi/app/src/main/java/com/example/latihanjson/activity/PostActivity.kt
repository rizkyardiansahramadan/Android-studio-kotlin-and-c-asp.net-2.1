package com.example.latihanjson.activity

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.latihanjson.R
import com.example.latihanjson.adapter.PostAdapter
import com.example.latihanjson.api.RetrofitClient
import com.example.latihanjson.model.PostResponse
import kotlinx.android.synthetic.main.activity_post.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class PostActivity : AppCompatActivity(){

    private var list = ArrayList<PostResponse>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_post)
        showPosts()

    }

    private fun showPosts() {
        rvPost.setHasFixedSize(true)
        rvPost.layoutManager = LinearLayoutManager(this)
        RetrofitClient.instance.getPosts().enqueue(object: Callback<ArrayList<PostResponse>>{
            override fun onFailure(call: Call<ArrayList<PostResponse>>, t: Throwable) {
                tvResponseCode.text = t.message
            }

            override fun onResponse(
                call: Call<ArrayList<PostResponse>>,
                response: Response<ArrayList<PostResponse>>
            ) {
                tvResponseCode.text = response.code().toString()
                val listResponse = response.body()
                listResponse?.let { list.addAll(it) }
                val adapter = PostAdapter(list)
                rvPost.adapter = adapter
            }

        })
    }
}