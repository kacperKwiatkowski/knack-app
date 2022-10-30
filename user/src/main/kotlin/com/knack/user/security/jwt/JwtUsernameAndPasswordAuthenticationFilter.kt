package com.knack.user.security.jwt

import com.fasterxml.jackson.databind.ObjectMapper
import io.jsonwebtoken.Jwts
import org.springframework.security.authentication.AuthenticationManager
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken
import org.springframework.security.core.Authentication
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter
import java.io.IOException
import java.sql.Date
import java.time.LocalDate
import javax.crypto.SecretKey
import javax.naming.AuthenticationException
import javax.servlet.FilterChain
import javax.servlet.ServletException
import javax.servlet.http.HttpServletRequest
import javax.servlet.http.HttpServletResponse

class JwtUsernameAndPasswordAuthenticationFilter(
    private val authenticationManager: AuthenticationManager,
    private val jwtConfig: JwtConfig,
    private val secretKey: SecretKey,
    private val objectMapper: ObjectMapper
) : UsernamePasswordAuthenticationFilter() {

    @Throws(AuthenticationException::class)
    override fun attemptAuthentication(
        request: HttpServletRequest,
        response: HttpServletResponse?
    ): Authentication {
        return try {
            val authenticationRequest: UsernameAndPasswordAuthenticationRequest = objectMapper
                .readValue(
                    request.inputStream,
                    UsernameAndPasswordAuthenticationRequest::class.java
                )
            val authentication: Authentication = UsernamePasswordAuthenticationToken(
                authenticationRequest.username,
                authenticationRequest.password
            )
            authenticationManager.authenticate(authentication)
        } catch (e: IOException) {
            throw RuntimeException(e)
        }
    }

    @Throws(IOException::class, ServletException::class)
    override fun successfulAuthentication(
        request: HttpServletRequest?,
        response: HttpServletResponse,
        chain: FilterChain?,
        authResult: Authentication
    ) {
        val token: String = Jwts.builder()
            .setSubject(authResult.name)
            .claim("authorities", authResult.authorities)
            .setIssuedAt(java.util.Date())
            .setExpiration(Date.valueOf(LocalDate.now().plusDays(jwtConfig.tokenExpirationAfterDays!!.toLong())))
            .signWith(secretKey)
            .compact()
        val body = "{\"jwt\": \"" + jwtConfig.tokenPrefix + token + "\"}"

        //TODO Check for safer options (cookie perhaps)
        response
            .getWriter().write(body)
        response
            .addHeader(
                jwtConfig.getAuthorizationHeader(),
                jwtConfig.tokenPrefix + token
            )
    }
}