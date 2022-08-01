package com.example.latihanjson.activity

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.latihanjson.R
import com.example.latihanjson.adapter.UserAdapter
import com.example.latihanjson.api.RetrofitClient
import com.example.latihanjson.model.User
import com.example.latihanjson.model.UserResponse
import kotlinx.android.synthetic.main.activity_user.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class UserActivity : AppCompatActivity() {

    private var list = ArrayList<User>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_user)

        showUsers()
    }

    private fun showUsers() {
        rvUser.setHasFixedSize(true);
        rvUser.layoutManager = LinearLayoutManager(this)
        RetrofitClient.instance.getUsers().enqueue(object : Callback<UserResponse>{
            override fun onFailure(call: Call<UserResponse>, t: Throwable) {
                tvResponseCode.text = t.message
            }
            override fun onResponse(call: Call<UserResponse>, response: Response<UserResponse>) {
                tvResponseCode.text = response.code().toString()
                val listResponse = response.body()?.data
                listResponse?.let { list.addAll(it) }
                val adapter = UserAdapter(list)
                rvUser.adapter = adapter
            }
        })

    }
}
