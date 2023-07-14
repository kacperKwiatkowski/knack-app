package com.knack.user.repository

import com.knack.user.model.UserEntity
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.data.repository.CrudRepository
import org.springframework.stereotype.Repository
import java.util.*

@Repository
interface UserRepository : JpaRepository<UserEntity, Long> {

    fun findByUsernameOrEmail(username: String, email: String): UserEntity

}
