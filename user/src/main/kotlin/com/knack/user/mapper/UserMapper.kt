package com.knack.user.mapper

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.model.UserEntity
import com.knack.user.security.role.RoleType
import org.modelmapper.ModelMapper
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder
import org.springframework.security.crypto.password.PasswordEncoder
import org.springframework.stereotype.Component

@Component
class UserMapper(
    private val modelMapper: ModelMapper,
    private val passwordEncoder: PasswordEncoder
) {

    fun mapCreateUserDTOToUserEntity(userToMap: UserCreateDTO): UserEntity{
        val mappedUser = modelMapper.map(userToMap, UserEntity::class.java)
        mappedUser.password = passwordEncoder.encode(userToMap.password)
        mappedUser.roleType = RoleType.valueOf(userToMap.roleType)
        return mappedUser;
    }

    fun mapUserEntityToUserDTO(userToMap: UserEntity): UserDTO {

        return UserDTO(
            userToMap.id,
            userToMap.firstName,
            userToMap.lastName,
            userToMap.email,
            userToMap.username,
            userToMap.contactNumber,
            userToMap.password,
            userToMap.roleType.toString()
        )
//        return modelMapper.map(userToMap, UserDTO::class.java)
    }
}
