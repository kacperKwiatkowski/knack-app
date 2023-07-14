package com.knack.user.service

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.dto.UserLoginDTO
import com.knack.user.mapper.UserMapper
import com.knack.user.model.UserEntity
import com.knack.user.repository.UserRepository
import org.springframework.security.core.userdetails.UserDetails
import org.springframework.security.core.userdetails.UserDetailsService
import org.springframework.security.core.userdetails.UsernameNotFoundException
import org.springframework.stereotype.Service

@Service
class AuthService(
    private val userRepository: UserRepository,
    private val userMapper: UserMapper,
): UserDetailsService {

    fun createUser (userCreateRequest: UserCreateDTO): UserDTO {
        return userMapper.mapUserEntityToUserDTO(
            userRepository.save(
                userMapper.mapCreateUserDTOToUserEntity(userCreateRequest)))
    }

    override fun loadUserByUsername(username: String): UserDetails {
        try {
            val user: UserEntity = userRepository.findByUsernameOrEmail(username, username)
             return org.springframework.security.core.userdetails.User.builder()
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
