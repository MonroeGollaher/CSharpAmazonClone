<template>
  <div class="activeitem container-fluid">
    <div class="row">
      <div class="col-4 card shadow">
        <img :src="activeItem.image" class="img-fluid" />
      </div>
      <div class="col-8">
        <h3>{{ activeItem.title }}</h3>
        <h4>${{ activeItem.price }}</h4>
        <p>{{ activeItem.body }}</p>
        <div class="div" v-if="profile.id">
          <button @click="deleteItem(activeItem.id)" class="btn bg-transparent text-danger">
            <i class="fas fa-times"></i>
          </button>
          <button class="btn bg-transparent text-primary" data-toggle="modal" :data-target="'#editModal' + activeItem.id">
            <i class="far fa-edit"></i>
          </button>
          <button class="btn bg-transparent text-success">
            <i class="fas fa-list-ol"></i>
          </button>

          <!-- <select @change.prevent="addToList" v-model="state.listId">
            <option disabled value="">
              Add to list...
            </option>
            <option class="text-light" v-for="l in lists" :key="l.id" :value="l.id">
              {{ l.title }}
            </option>
          </select> -->
        </div>
      </div>
    </div>
  </div>
  <form class="form" @submit.prevent="addToList(activeItem.id, state.listId)">
    <div class="row justify-content-center">
      <select v-model="state.listId"
              name=""
              id=""
              class="m-2 w-75"
              data-option-label="Select a List"
              required
      >
        <option disabled value="">
          Select a List
        </option>
        <option v-for="list in lists" :key="list.id" :value="list.id">
          {{ list.title }}
        </option>
      </select>
    </div>
    <div class="row justify-content-center">
      <button type="submit" class="btn btn-outline-dark btn-light w-75 m-2 border-dark" v-if="profile.id">
        Add to Wishlist
      </button>
    </div>
  </form>

  <!-- Modal -->
  <div class="modal fade"
       :id="'editModal' + activeItem.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Edit your item
          </h5>
          <form @submit="editItem(state.editedItem, activeItem.id)">
            <div class="form-group">
              <label for="itemTitle">Product title</label>
              <input type="text"
                     class="form-control"
                     id="itemTitle"
                     aria-describedby="itemTitle"
                     placeholder="What's your item called?"
                     v-model="state.editedItem.title"
              >
            </div>
            <div class="form-group">
              <label for="itemDescription">Description</label>
              <input type="text"
                     class="form-control"
                     id="itemDescription"
                     placeholder="How would your describe your product?"
                     v-model="state.editedItem.body"
              >
            </div>
            <div class="form-group">
              <label for="image">Image</label>
              <input type="text" class="form-control" placeholder="Picture" v-model="state.editedItem.image">
            </div>
            <div class="form-group">
              <label for="price">Price</label>
              <input type="number"
                     class="form-control"
                     id="itemPrice"
                     placeholder="How much does your item cost?"
                     v-model="state.editedItem.price"
              >
            </div>
            <div class="form-group">
              <label for="price">Sale Price</label>
              <input type="number"
                     class="form-control"
                     id="salePrice"
                     placeholder="If your item goes on sale, how much will it cost?"
                     v-model="state.editedItem.salePrice"
              >
            </div>
            <div class="form-group">
              <label for="itemQuantity">Quantity</label>
              <input type="number"
                     class="form-control"
                     id="itemQuantity"
                     placeholder="How many items do you have to sell?"
                     v-model="state.editedItem.quantity"
              >
            </div>
            <div class="form-group">
              <label for="image">Published?</label>
              <input class="ml-3" type="checkbox" v-model="state.editedItem.isAvailable">
            </div>
            <button type="submit" class="btn btn-primary mb-3">
              Edit Item
            </button>
          </form>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { itemsService } from '../services/ItemsService'
import { listItemsService } from '../services/ListItemService'
import { listsService } from '../services/ListsService'
export default {
  name: 'Activeitem',
  setup() {
    const state = reactive({
      editedItem: {

      },
      listId: null
    })
    onMounted(() => {
      listsService.getLists()
    })
    return {
      state,
      lists: computed(() => AppState.lists),
      profile: computed(() => AppState.profile),
      activeItem: computed(() => AppState.activeItem),
      deleteItem(id) {
        itemsService.deleteItem(id)
      },
      editItem(editedItem, id) {
        itemsService.editItem(state.editedItem, id)
      },
      async addToList(listId, itemId) {
        const newItem = {
          listId: listId,
          itemId: itemId
        }
        listItemsService.addItemToList(newItem)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img {
  width: 400px;
  height: 300px;
}
</style>
