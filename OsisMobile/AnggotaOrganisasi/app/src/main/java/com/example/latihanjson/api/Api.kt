package com.example.latihanjson.api

import com.example.latihanjson.model.PostResponse
import com.example.latihanjson.model.UserResponse
import retrofit2.Call
import retrofit2.http.GET

interface Api {
    @GET("DataOsis1.Json")
    fun getUsers(): Call<UserResponse>

    @GET("https://jsonplaceholder.typicode.com/posts")
    fun getPosts(): Call<ArrayList<PostResponse>>
}