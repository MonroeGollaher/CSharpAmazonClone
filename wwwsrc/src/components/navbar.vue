<template>
  <nav class="navbar navbar-expand-lg navbar-dark nav">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h3 class="">
          <i class="fas fa-store mr-3"></i>Amazen
        </h3>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarText">
      <span class="navbar-text">
        <button
          class="btn btn-outline-primary text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle"
            @click="state.dropOpen = !state.dropOpen"
          >
            <!-- <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded-circle"
            /> -->
            <span class="mx-2 text-light">{{ user.name }}</span>
          </div>
          <div
            class="dropdown-menu p-0 list-group w-100"
            :class="{ show: state.dropOpen }"
            @click="state.dropOpen = false"
          >
            <router-link :to="{ name: 'Profile' }">
              <div class="list-group-item list-group-item-action hoverable">
                Profile
              </div>
            </router-link>
            <div
              class="list-group-item list-group-item-action hoverable"
              @click="logout"
            >
              logout
            </div>
          </div>
        </div>
      </span>
    </div>
  </nav>
  <div class="row justify-content-around align-items-center bottom-nav d-flex">
    <div class="col-3">
      <div class="row justify-content-center  align-items-center">
        <div class="col-4">
          <router-link :to="{ name: 'Home' }" class="nav-link">
            Store
          </router-link>
        </div>
        <div class="col-4">
          <router-link :to="{ name: 'Profile' }" class="nav-link">
            Profile
          </router-link>
        </div>
      </div>
    </div>
    <div class="col-6">
      <form @submit="search">
        <div class="">
          <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Search for an item...">
          <div id="emailHelp" class="form-text">
          </div>
        </div>
      </form>
    </div>
    <div class="col-3">
      <div class="row justify-content-center align-items-center">
        <div class="col-6 mt-1">
          <new-item-component />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
.nav {
  background: rgb(255, 165, 90)
}
.bottom-nav{
  background: rgb(219, 146, 84);
}
.nav-link {
  color: white;
}
</style>
