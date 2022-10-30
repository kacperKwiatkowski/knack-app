package com.knack.user.security.auth

import com.knack.user.model.UserEntity
import com.knack.user.repository.UserRepository
import org.springframework.security.core.userdetails.UserDetails
import org.springframework.security.core.userdetails.UserDetailsService
import org.springframework.security.core.userdetails.UsernameNotFoundException
import org.springframework.stereotype.Service

@Service
class UserAuthService (
    private val userRepository: UserRepository
): UserDetailsService {

    @Throws(UsernameNotFoundException::class)
    override fun loadUserByUsername(username: String): UserDetails {
        return try {
            val user: UserEntity = userRepository.findByUsername(username)
            org.springframework.security.core.userdetails.User.builder()
                .username(user.username)
                .password(user.password)
                .authorities(user.roleType.getGrantedAuthorities())
                .accountExpired(false)
                .accountLocked(false)
                .credentialsExpired(false)
                .disabled(false)
                .build()
        } catch (e: Exception) {
            throw UsernameNotFoundException(String.format("Username %s not found", username))
        }
    }
}