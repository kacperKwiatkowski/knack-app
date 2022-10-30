package com.knack.user.security.role

import com.google.common.collect.Sets
import org.springframework.security.core.authority.SimpleGrantedAuthority
import java.util.stream.Collectors.toSet

enum class RoleType(private val permissions: Set<RoleAuthorities>) {
    USER(Sets.newHashSet(RoleAuthorities.AUTHENTICATED));

    fun getGrantedAuthorities(): Set<SimpleGrantedAuthority>{
            val permissions: MutableSet<SimpleGrantedAuthority> = permissions.stream()
                .map{ permission -> SimpleGrantedAuthority(permission.permission) }
                .collect(toSet())
            permissions.add(SimpleGrantedAuthority("ROLE_" + name))
            return permissions
        }
}